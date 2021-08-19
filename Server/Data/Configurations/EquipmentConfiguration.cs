using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {

  internal class EquipmentConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Equipment>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .ValueGeneratedOnAdd()
          .HasColumnName("id");
        entity.Property(e => e.Name)
          .HasMaxLength(50);
        entity.Property(e => e.Brand)
          .HasMaxLength(30);
        entity.Property(e => e.Model)
          .HasMaxLength(30);
        entity.Property(e => e.RegistryNumber)
          .HasMaxLength(15);
      });
      builder.Entity<Equipment>()
        .HasOne(e => e.User)
        .WithMany(e => e.Equipment)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<Equipment>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.Equipment)
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