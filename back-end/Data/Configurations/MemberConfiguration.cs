using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {
  internal class MemberConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Member>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.FirstName).HasMaxLength(15);
        entity.Property(e => e.LastName).HasMaxLength(15);
        entity.Property(e => e.Pesel).HasMaxLength(11);
      });

      builder.Entity<Member>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.Member)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Member>()
        .HasOne(e => e.User)
        .WithMany(e => e.Members)
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