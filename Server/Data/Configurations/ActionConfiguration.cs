using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Server.Data.Configurations {

  internal class ActionConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Action>(entity => {
        /// Properties
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .IsRequired()
          .ValueGeneratedOnAdd();
        entity.Property(e => e.Type)
          .IsRequired()
          .HasDefaultValue(ActionType.Fire);
        entity.Property(e => e.Location)
          .IsRequired()
          .HasMaxLength(64);
        entity.Property(e => e.StartTime)
          .IsRequired();
        entity.Property(e => e.EndTime)
          .IsRequired();
        entity.Property(e => e.UserId)
          .HasColumnName("OwnerId")
          .IsRequired();
        /// Relations
        entity.HasOne(e => e.User)
          .WithMany(e => e.Actions)
          .OnDelete(DeleteBehavior.NoAction);
        entity.HasMany(e => e.Members)
          .WithOne(e => e.Action)
          .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(e => e.Equipment)
          .WithOne(e => e.Action)
          .OnDelete(DeleteBehavior.Cascade);
      });
    }

    public void SeedData(ModelBuilder builder) {
      // builder.Entity<>().HasData(
      //   new {

      //   }
      // );
    }

  }

}