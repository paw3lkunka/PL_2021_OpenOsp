using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {
  internal class ActionEquipmentConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionEquipment>(entity => {
        entity.HasKey(e => new { e.ActionId, e.EquipmentId });
        entity.Property(e => e.CounterState).HasDefaultValue(0.0f);
        entity.Property(e => e.FuelUsed).HasDefaultValue(0.0f);
      });

      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Equipment)
        .HasForeignKey(e => e.ActionId)
        .OnDelete(DeleteBehavior.NoAction);

      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Equipment)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.EquipmentId)
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