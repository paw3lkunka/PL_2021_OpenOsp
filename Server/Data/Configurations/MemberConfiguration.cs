using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {
  internal class MemberConfiguration : IEntityConfiguration {
    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Member>(entity => {
        /// Properties
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .IsRequired()
          .ValueGeneratedOnAdd();
        entity.Property(e => e.FirstName)
          .IsRequired()
          .HasMaxLength(24);
        entity.Property(e => e.LastName)
          .IsRequired()
          .HasMaxLength(24);
        entity.Property(e => e.Pesel)
          .HasColumnType("char(11)")
          .IsRequired()
          .HasMaxLength(11);
        entity.Property(e => e.UserId)
          .HasColumnName("OwnerId")
          .IsRequired();
        /// Relations
        entity.HasOne(e => e.User)
          .WithMany(e => e.Members)
          .OnDelete(DeleteBehavior.NoAction);
        entity.HasMany(e => e.Actions)
          .WithOne(e => e.Member)
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