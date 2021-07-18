using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Data.Configurations {
  internal class ActionMemberConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionMember>(entity => {
        entity.HasKey(e => new { e.Key1, e.Key2 });
        entity.Property(e => e.Key1)
          .HasColumnName("action_id");
        entity.Property(e => e.Key2)
          .HasColumnName("member_id");
        entity.Property(e => e.Role)
          .HasDefaultValue(ActionMemberRole.Member);
      });
      builder.Entity<ActionMember>()
        .HasOne(e => e.Action)
        .WithMany(e => e.Members)
        .HasForeignKey(e => e.Key1)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<ActionMember>()
        .HasOne(e => e.Member)
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