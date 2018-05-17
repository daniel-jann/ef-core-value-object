using System;
using JetBrains.Annotations;

namespace EFCoreValueObject.Model
{
  public class Bank
  {
    public Guid Id { get; [UsedImplicitly] private set; } = new Guid();

  }
}