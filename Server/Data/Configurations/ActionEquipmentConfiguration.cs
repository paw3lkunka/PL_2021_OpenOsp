using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations; 

internal class ActionEquipmentConfiguration : IEntityConfiguration {
  public void AddConfiguration(ModelBuilder builder) {
    builder.Entity<ActionEquipment>(entity => {
      /// Properties
      entity.HasKey(e => new {e.Id, e.Id2});
      entity.Property(e => e.Id)
        .HasColumnName("ActionId")
        .IsRequired();
      entity.Property(e => e.Id2)
        .HasColumnName("EquipmentId")
        .IsRequired();
      entity.Property(e => e.CounterState)
        .IsRequired()
        .HasDefaultValue(0);
      entity.Property(e => e.FuelUsed)
        .IsRequired()
        .HasDefaultValue(0.0f);
      /// Relations
      entity.HasOne(e => e.Action)
        .WithMany(e => e.Equipment)
        .HasForeignKey(e => e.Id)
        .OnDelete(DeleteBehavior.NoAction);
      entity.HasOne(e => e.Equipment)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.Id2)
        .OnDelete(DeleteBehavior.NoAction);
    });
  }

  public void SeedData(ModelBuilder builder) {
    // builder.Entity<>().HasData(
    //   new {

    //   }
    // );
  }
}