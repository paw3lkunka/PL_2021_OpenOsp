using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Data.Configurations {
  internal class ActionMemberConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionMember>(entity => {
        entity.HasKey(e => new { e.ActionId, e.MemberId });
        entity.Property(e => e.Role).HasDefaultValue(ActionMemberRole.Member);
      });

      builder.Entity<ActionMember>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Members)
        .HasForeignKey(e => e.ActionId)
        .OnDelete(DeleteBehavior.NoAction);

      builder.Entity<ActionMember>()
        .HasOne(e => e.Member)
        .WithMany(e => e.Actions)
        .HasForeignKey(e => e.MemberId)
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