using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;

namespace OpenOsp.Data.Configurations {

  internal class MemberConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Member>(entity => {
        entity.HasKey(e => e.Key);
        entity.Property(e => e.Key)
          .ValueGeneratedOnAdd()
          .HasColumnName("id");
        entity.Property(e => e.FirstName)
          .HasMaxLength(15);
        entity.Property(e => e.LastName)
          .HasMaxLength(15);
        entity.Property(e => e.Pesel)
          .HasMaxLength(11);
      });
      builder.Entity<Member>()
        .HasOne(e => e.User)
        .WithMany(e => e.Members)
        .HasForeignKey(e => e.UserKey)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<Member>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.Member)
        .HasForeignKey(e => e.Key2)
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