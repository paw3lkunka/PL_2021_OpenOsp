using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {
  internal class ActionEquipmentConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionEquipment>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.CounterState).HasDefaultValue(0);
        entity.Property(e => e.FuelUsed).HasDefaultValue(0);
      });

      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Equipment)
        .OnDelete(DeleteBehavior.NoAction);

      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Equipment)
        .WithMany(e => e.Actions)
        .OnDelete(DeleteBehavior.NoAction);
    }

    public void SeedData(ModelBuilder builder) {
      // builder.Entity<>().HasData(
      //   new {

      //   }
      // );
    }
  }
}