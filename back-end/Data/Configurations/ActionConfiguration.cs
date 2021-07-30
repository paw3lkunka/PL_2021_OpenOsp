using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Data.Configurations {

  internal class ActionConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Action>(entity => {
        entity.HasKey(e => e.Key);
        entity.Property(e => e.Key)
          .ValueGeneratedOnAdd()
          .HasColumnName("id");
        entity.Property(e => e.Type)
          .HasDefaultValue(ActionType.Fire)
          .IsRequired();
        entity.Property(e => e.Location)
          .HasMaxLength(50);
        entity.Property(e => e.StartTime)
          .IsRequired();
        entity.Property(e => e.EndTime)
          .IsRequired();
      });
      builder.Entity<Action>()
        .HasOne(e => e.User)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.UserKey)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<Action>()
        .HasMany(e => e.Members)
        .WithOne(e => e.Action)
        .HasForeignKey(e => e.Key1)
        .OnDelete(DeleteBehavior.Cascade);
      builder.Entity<Action>()
        .HasMany(e => e.Equipment)
        .WithOne(e => e.Action)
        .HasForeignKey(e => e.Key1)
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