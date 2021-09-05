using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {

  internal class UserConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      /// Users
      builder.Entity<User>(entity => {
        /// Properties
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .ValueGeneratedOnAdd();
        entity.Property(e => e.Email)
          .IsRequired()
          .HasMaxLength(256);
        entity.Property(e => e.NormalizedEmail)
          .HasMaxLength(256);
        entity.Property(e => e.NormalizedUserName)
          .HasMaxLength(16);
        entity.Property(e => e.PhoneNumber)
          .HasMaxLength(32);
        entity.Property(e => e.UserName)
          .IsRequired()
          .HasMaxLength(16);
        entity.Property(e => e.EmailConfirmed)
          .IsRequired()
          .HasDefaultValue(false);
        /// Relations
        entity.HasMany(e => e.Actions)
          .WithOne(e => e.User)
          .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(e => e.Equipment)
          .WithOne(e => e.User)
          .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(e => e.Members)
          .WithOne(e => e.User)
          .OnDelete(DeleteBehavior.Cascade);
      });
      /// UserClaims
      // builder.Entity<TUserClaim>(b =>
      // {
      //     b.HasKey(uc => uc.Id);
      //     b.ToTable("AspNetUserClaims");
      // });
      // /// UserLogins
      // builder.Entity<TUserLogin>(b =>
      // {
      //     b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
      //     b.Property(l => l.LoginProvider).HasMaxLength(128);
      //     b.Property(l => l.ProviderKey).HasMaxLength(128);
      //     b.ToTable("AspNetUserLogins");
      // });
      // /// UserTokens
      // builder.Entity<TUserToken>(b =>
      // {
      //     b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
      //     b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
      //     b.Property(t => t.Name).HasMaxLength(maxKeyLength);
      //     b.ToTable("AspNetUserTokens");
      // });
    }

    public void SeedData(ModelBuilder builder) {
      // builder.Entity<>().HasData(
      //   new {

      //   }
      // );
    }

  }

}