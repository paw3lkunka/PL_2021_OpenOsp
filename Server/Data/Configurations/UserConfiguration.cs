using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {

  internal class UserConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<User>(entity => {
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
      });
      builder.Entity<User>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.User)
        .OnDelete(DeleteBehavior.Cascade);
      builder.Entity<User>()
        .HasMany(e => e.Equipment)
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