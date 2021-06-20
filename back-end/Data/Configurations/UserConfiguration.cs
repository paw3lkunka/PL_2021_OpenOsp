using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {
  internal class UserConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<User>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.ConcurrencyStamp).HasMaxLength(85);
        entity.Property(e => e.Email).HasMaxLength(85);
        entity.Property(e => e.NormalizedEmail).HasMaxLength(85);
        entity.Property(e => e.NormalizedUserName).HasMaxLength(30);
        entity.Property(e => e.PasswordHash).HasMaxLength(85);
        entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        entity.Property(e => e.SecurityStamp).HasMaxLength(85);
        entity.Property(e => e.UserName).HasMaxLength(30);
        entity.Property(e => e.EmailConfirmed).HasDefaultValue(false);
      });

      builder.Entity<User>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.User)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<User>()
        .HasMany(e => e.Equipments)
        .WithOne(e => e.User)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<User>()
        .HasMany(e => e.Members)
        .WithOne(e => e.User)
        .OnDelete(DeleteBehavior.Cascade);
    }

    public void SeedData(ModelBuilder builder) {
      // builder.Entity<>().HasData(
      //   new {

      //   }
      // );
    }
  }
}