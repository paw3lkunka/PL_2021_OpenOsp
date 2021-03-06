// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Data.Migrations {
  [DbContext(typeof(AppDbContext))]
  [Migration("20210817195739_ReInit")]
  partial class ReInit {
    protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 63)
          .HasAnnotation("ProductVersion", "5.0.9")
          .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        b.Property<string>("ClaimType")
            .HasColumnType("text");

        b.Property<string>("ClaimValue")
            .HasColumnType("text");

        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("AspNetUserClaims");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b => {
        b.Property<string>("LoginProvider")
            .HasColumnType("text");

        b.Property<string>("ProviderKey")
            .HasColumnType("text");

        b.Property<string>("ProviderDisplayName")
            .HasColumnType("text");

        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.HasKey("LoginProvider", "ProviderKey");

        b.HasIndex("UserId");

        b.ToTable("AspNetUserLogins");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b => {
        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.Property<string>("LoginProvider")
            .HasColumnType("text");

        b.Property<string>("Name")
            .HasColumnType("text");

        b.Property<string>("Value")
            .HasColumnType("text");

        b.HasKey("UserId", "LoginProvider", "Name");

        b.ToTable("AspNetUserTokens");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasColumnName("id")
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        b.Property<DateTime>("EndTime")
            .HasColumnType("timestamp without time zone");

        b.Property<string>("Location")
            .HasMaxLength(50)
            .HasColumnType("character varying(50)");

        b.Property<DateTime>("StartTime")
            .HasColumnType("timestamp without time zone");

        b.Property<int>("Type")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasDefaultValue(2);

        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionEquipment", b => {
        b.Property<int>("Id1")
            .HasColumnType("integer")
            .HasColumnName("action_id");

        b.Property<int>("Id2")
            .HasColumnType("integer")
            .HasColumnName("equipment_id");

        b.Property<int>("CounterState")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasDefaultValue(0);

        b.Property<float>("FuelUsed")
            .ValueGeneratedOnAdd()
            .HasColumnType("real")
            .HasDefaultValue(0f);

        b.HasKey("Id1", "Id2");

        b.HasIndex("Id2");

        b.ToTable("ActionEquipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionMember", b => {
        b.Property<int>("Id1")
            .HasColumnType("integer")
            .HasColumnName("action_id");

        b.Property<int>("Id2")
            .HasColumnType("integer")
            .HasColumnName("member_id");

        b.Property<int>("Role")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasDefaultValue(0);

        b.HasKey("Id1", "Id2");

        b.HasIndex("Id2");

        b.ToTable("ActionMembers");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasColumnName("id")
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        b.Property<string>("Brand")
            .HasMaxLength(30)
            .HasColumnType("character varying(30)");

        b.Property<string>("Model")
            .HasMaxLength(30)
            .HasColumnType("character varying(30)");

        b.Property<string>("Name")
            .HasMaxLength(50)
            .HasColumnType("character varying(50)");

        b.Property<string>("RegistryNumber")
            .HasMaxLength(15)
            .HasColumnType("character varying(15)");

        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Equipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasColumnName("id")
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        b.Property<string>("FirstName")
            .HasMaxLength(15)
            .HasColumnType("character varying(15)");

        b.Property<string>("LastName")
            .HasMaxLength(15)
            .HasColumnType("character varying(15)");

        b.Property<string>("Pesel")
            .HasMaxLength(11)
            .HasColumnType("character varying(11)");

        b.Property<int>("UserId")
            .HasColumnType("integer");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Members");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.User", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("integer")
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        b.Property<int>("AccessFailedCount")
            .HasColumnType("integer");

        b.Property<string>("ConcurrencyStamp")
            .IsConcurrencyToken()
            .HasMaxLength(85)
            .HasColumnType("character varying(85)");

        b.Property<string>("Email")
            .HasMaxLength(85)
            .HasColumnType("character varying(85)");

        b.Property<bool>("EmailConfirmed")
            .ValueGeneratedOnAdd()
            .HasColumnType("boolean")
            .HasDefaultValue(false);

        b.Property<bool>("LockoutEnabled")
            .HasColumnType("boolean");

        b.Property<DateTimeOffset?>("LockoutEnd")
            .HasColumnType("timestamp with time zone");

        b.Property<string>("NormalizedEmail")
            .HasMaxLength(85)
            .HasColumnType("character varying(85)");

        b.Property<string>("NormalizedUserName")
            .HasMaxLength(30)
            .HasColumnType("character varying(30)");

        b.Property<string>("PasswordHash")
            .HasMaxLength(85)
            .HasColumnType("character varying(85)");

        b.Property<string>("PhoneNumber")
            .HasMaxLength(20)
            .HasColumnType("character varying(20)");

        b.Property<bool>("PhoneNumberConfirmed")
            .HasColumnType("boolean");

        b.Property<string>("SecurityStamp")
            .HasMaxLength(85)
            .HasColumnType("character varying(85)");

        b.Property<bool>("TwoFactorEnabled")
            .HasColumnType("boolean");

        b.Property<string>("UserName")
            .HasMaxLength(30)
            .HasColumnType("character varying(30)");

        b.HasKey("Id");

        b.HasIndex("NormalizedEmail")
            .HasDatabaseName("EmailIndex");

        b.HasIndex("NormalizedUserName")
            .IsUnique()
            .HasDatabaseName("UserNameIndex");

        b.ToTable("AspNetUsers");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Actions")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionEquipment", b => {
        b.HasOne("OpenOsp.Model.Models.Action", "Action")
            .WithMany("Equipment")
            .HasForeignKey("Id1")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        b.HasOne("OpenOsp.Model.Models.Equipment", "Equipment")
            .WithMany("Actions")
            .HasForeignKey("Id2")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("Action");

        b.Navigation("Equipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionMember", b => {
        b.HasOne("OpenOsp.Model.Models.Action", "Action")
            .WithMany("Members")
            .HasForeignKey("Id1")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        b.HasOne("OpenOsp.Model.Models.Member", "Member")
            .WithMany("Actions")
            .HasForeignKey("Id2")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("Action");

        b.Navigation("Member");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Equipment")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Members")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.Navigation("Equipment");

        b.Navigation("Members");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.Navigation("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.Navigation("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.User", b => {
        b.Navigation("Actions");

        b.Navigation("Equipment");

        b.Navigation("Members");
      });
#pragma warning restore 612, 618
    }
  }
}
