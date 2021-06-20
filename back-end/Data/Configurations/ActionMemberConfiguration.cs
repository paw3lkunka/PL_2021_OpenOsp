using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Data.Configurations {
  internal class ActionMemberConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionMember>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Role).HasDefaultValue(ActionMemberRole.Member);
      });

      builder.Entity<ActionMember>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Members)
        .OnDelete(DeleteBehavior.NoAction);

      builder.Entity<ActionMember>()
        .HasOne(e => e.Member)
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