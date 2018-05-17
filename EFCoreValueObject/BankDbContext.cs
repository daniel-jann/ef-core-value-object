using System.Linq;
using EFCoreValueObject.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreValueObject
{
  public class BankDbContext : DbContext
  {
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
    {
    }

    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankLayoutSettings> BankLayoutSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      ConfigureBank(modelBuilder);
      ConfigureBankLayoutSettings(modelBuilder);
    }
    
    private static void ConfigureBank(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BankLayoutSettings>(b =>
        {
          b.HasOne<Bank>()
            .WithOne()
            .HasForeignKey<BankLayoutSettings>(x => x.BankId);
        }
      );
    }

    private static void ConfigureBankLayoutSettings(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BankLayoutSettings>(b =>
      {
        b.HasKey(x => x.BankId);
        b.OwnsOne(
          o => o.HeaderAndFooterBackgroundColor,
          sa => sa.Property("_hashPrefixedHexTriplet").HasColumnName("HeaderAndFooterBackgroundColor")
        );
        b.OwnsOne(
          o => o.HeaderForeColor,
          sa => sa.Property("_hashPrefixedHexTriplet").HasColumnName("HeaderForeColor")
        );
        b.OwnsOne(
          o => o.FooterForeColor,
          sa => sa.Property("_hashPrefixedHexTriplet").HasColumnName("FooterForeColor")
        );
        b.OwnsOne(
          o => o.TitlesForeColor,
          sa => sa.Property("_hashPrefixedHexTriplet").HasColumnName("TitlesForeColor")
        );
      });
    }
  }
}