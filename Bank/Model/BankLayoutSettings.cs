using System;

namespace Bank.Model
{
  public class BankLayoutSettings
  {
    public Guid BankId { get; set; }
    public Color HeaderAndFooterBackgroundColor { get; set; }
    public Color HeaderForeColor { get; set; }
    public Color FooterForeColor { get; set; }
    public Color TitlesForeColor { get; set; }
    public string LogoKey { get; set; }
  }
}