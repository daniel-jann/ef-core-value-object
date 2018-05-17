using System.Linq;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var dbContext = new BankDbContext();
      ApplyMigrations(dbContext);
      AddBank(dbContext);
      AddBankLayoutSettings(dbContext);
    }

    private static void AddBankLayoutSettings(BankDbContext dbContext)
    {
      var bankLayoutSettings = new BankLayoutSettings();
      bankLayoutSettings.BankId = dbContext.Banks.First().Id;
      bankLayoutSettings.HeaderAndFooterBackgroundColor = Color.Empty;
      bankLayoutSettings.FooterForeColor = Color.Empty;
      bankLayoutSettings.HeaderForeColor = Color.Empty;
      bankLayoutSettings.TitlesForeColor = Color.Empty;
      dbContext.Add(bankLayoutSettings);
      dbContext.SaveChanges();
    }

    private static void AddBank(BankDbContext dbContext)
    {
      dbContext.Add(new Model.Bank());
      dbContext.SaveChanges();
    }

    private static void ApplyMigrations(BankDbContext context)
    {
      context.Database.Migrate();
      context.SaveChanges();
    }
  }
}