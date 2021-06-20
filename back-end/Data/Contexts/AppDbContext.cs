using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenOsp.Model.Models;
using OpenOsp.Data.Configurations;

namespace OpenOsp.Data.Contexts
{
  public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
  {
    public virtual DbSet<OpenOsp.Model.Models.Action> Actions { get; set; }
    public virtual DbSet<ActionEquipment> ActionEquipments { get; set; }
    public virtual DbSet<ActionMember> ActionMembers { get; set; }
    public virtual DbSet<Equipment> Equipments { get; set; }
    public virtual DbSet<Member> Members { get; set; }
    public override DbSet<User> Users { get; set; }

    public AppDbContext() : base() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      IList<IEntityConfiguration> entityConfigurations = new List<IEntityConfiguration> {
        new ActionConfiguration(),
        new ActionEquipmentConfiguration(),
        new ActionMemberConfiguration(),
        new EquipmentConfiguration(),
        new MemberConfiguration(),
        new UserConfiguration()
      };

      foreach (var entityConfiguration in entityConfigurations)
      {
        entityConfiguration.AddConfiguration(builder);
        entityConfiguration.SeedData(builder);
      }
    }
  }
}