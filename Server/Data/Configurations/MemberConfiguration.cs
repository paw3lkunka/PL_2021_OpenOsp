using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;

namespace OpenOsp.Server.Data.Configurations {

  internal class MemberConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<Member>(entity => {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
          .IsRequired()
          .ValueGeneratedOnAdd()
          .HasColumnName("id");
        entity.Property(e => e.FirstName)
          .IsRequired()
          .HasMaxLength(25);
        entity.Property(e => e.LastName)
          .IsRequired()
          .HasMaxLength(25);
        entity.Property(e => e.Pesel)
          .HasColumnType("varchar(11)")
          .IsRequired()
          .HasMaxLength(11);
      });
      builder.Entity<Member>()
        .HasOne(e => e.User)
        .WithMany(e => e.Members)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Entity<Member>()
        .HasMany(e => e.Actions)
        .WithOne(e => e.Member)
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