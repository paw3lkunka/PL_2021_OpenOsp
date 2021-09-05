using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {

  internal class EquipmentConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Equipment>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .IsRequired()
          .ValueGeneratedOnAdd()
          .HasColumnName("id");
        entity.Property(e => e.Brand)
          .IsRequired()
          .HasMaxLength(25);
        entity.Property(e => e.Model)
          .IsRequired()
          .HasMaxLength(25);
        entity.Property(e => e.RegistryNumber)
          .HasColumnType("varchar(15)")
          .IsRequired()
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