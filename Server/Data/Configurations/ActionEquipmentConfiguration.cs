using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {

  internal class ActionEquipmentConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionEquipment>(entity => {
        entity.HasKey(e => new { e.Id1, e.Id2 });
        entity.Property(e => e.Id1)
          .HasColumnName("action_id");
        entity.Property(e => e.Id2)
          .HasColumnName("equipment_id");
        entity.Property(e => e.CounterState)
          .HasDefaultValue(0.0f);
        entity.Property(e => e.FuelUsed)
          .HasDefaultValue(0.0f);
      });
      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Equipment)
        .HasForeignKey(e => e.Id1)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<ActionEquipment>()
        .HasOne(e => e.Equipment)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.Id2)
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