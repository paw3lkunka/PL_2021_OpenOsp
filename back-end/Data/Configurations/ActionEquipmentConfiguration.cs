using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {
  
  internal class ActionEquipmentConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionEquipment>(entity => {
        entity.HasKey(e => new { e.Key1, e.Key2 });
        entity.Property(e => e.Key1)
          .HasColumnName("action_id");
        entity.Property(e => e.Key2)
          .HasColumnName("equipment_id");
        entity.Property(e => e.CounterState)
          .HasDefaultValue(0.0f);
        entity.Property(e => e.FuelUsed)
          .HasDefaultValue(0.0f);
      });
      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Equipment)
        .HasForeignKey(e => e.Key1)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Equipment)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.Key2)
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