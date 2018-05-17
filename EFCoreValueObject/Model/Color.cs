using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace EFCoreValueObject.Model
{
  public sealed class Color
  {
    [UsedImplicitly]
    private string _hashPrefixedHexTriplet;

    public static Color Empty { get; } = new Color();

    public static Color FromHashPrefixedHexTriplet(string hashPrefixedHexTriplet)
    {
      if (hashPrefixedHexTriplet == null) 
        throw new ArgumentNullException("hashPrefixedHexTriplet", "The hashPrefixedHexTriplet parameter cannot be null");
      if (!Regex.IsMatch(hashPrefixedHexTriplet, "#[0-9A-Fa-f]{6}"))
        throw new FormatException(
          $"The hashPrefixedHexTriplet \"{hashPrefixedHexTriplet}\" is not a valid hex-triplet color. It should start with a hash (#) followed by 6 hexadecimal digits");
      return new Color(hashPrefixedHexTriplet);
    }

    /// <summary>
    /// Will update the toColor from the fromColor and return the toColor.
    /// If fromColor is null, will not do the update and return null.
    /// </summary>
    /// <param name="toColor"></param>
    /// <param name="fromColor"></param>
    /// <returns></returns>
    public static Color Update(Color toColor, Color fromColor)
    {
      if (fromColor == null)
      {
        return null;
      }

      return (toColor ?? new Color()).Update(fromColor);
    }

    private Color()
    {
    }

    private Color(string hashPrefixedHexTriplet)
    {
      _hashPrefixedHexTriplet = hashPrefixedHexTriplet;
    }

    /// <summary>
    /// Will return this object to allow chaining
    /// </summary>
    /// <param name="fromColor">Expected to be non null</param>
    public Color Update(Color fromColor)
    {
      _hashPrefixedHexTriplet = fromColor._hashPrefixedHexTriplet;
      return this;
    }

    public string ToHashPrefixedHexTriplet()
    {
      return _hashPrefixedHexTriplet;
    }

    public override string ToString()
    {
      return ToHashPrefixedHexTriplet();
    }
  }
}