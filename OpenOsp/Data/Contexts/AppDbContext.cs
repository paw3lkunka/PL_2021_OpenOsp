using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using OpenOsp.Api.Services;
using OpenOsp.Model.Models;
using OpenOsp.Data.Configurations;
using OpenOsp.Api.Exceptions;

namespace OpenOsp.Data.Contexts {

  public class AppDbContext : IdentityUserContext<User, int> {

    public AppDbContext() : base() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext(
      DbContextOptions<AppDbContext> options,
      IUserClaimsService userClaims
    ) : base(options) {
      _userId = userClaims.UserId;
    }

    private readonly int _userId;

    public virtual DbSet<OpenOsp.Model.Models.Action> Actions { get; set; }

    public virtual DbSet<ActionEquipment> ActionEquipment { get; set; }

    public virtual DbSet<ActionMember> ActionMembers { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public override DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);
      IList<IEntityConfiguration> entityConfigurations = new List<IEntityConfiguration> {
        new ActionConfiguration(),
        new ActionEquipmentConfiguration(),
        new ActionMemberConfiguration(),
        new EquipmentConfiguration(),
        new MemberConfiguration(),
        new UserConfiguration()
      };
      foreach (var entityConfiguration in entityConfigurations) {
        entityConfiguration.AddConfiguration(builder);
        entityConfiguration.SeedData(builder);
      }
      builder.Entity<Model.Models.Action>()
        .HasQueryFilter(e => e.UserId.Equals(_userId));
      builder.Entity<Equipment>()
        .HasQueryFilter(e => e.UserId.Equals(_userId));
      builder.Entity<Member>()
        .HasQueryFilter(e => e.UserId.Equals(_userId));
      builder.Entity<ActionEquipment>()
        .HasQueryFilter(e => e.Action.UserId.Equals(_userId));
      builder.Entity<ActionMember>()
        .HasQueryFilter(e => e.Action.UserId.Equals(_userId));
    }

    public override int SaveChanges() {
      if (_userId == default(int)) {
        throw new UnauthorizedException();
      }
      ChangeTracker.Entries()
        .Where(e => e.State.Equals(EntityState.Added))
        .ToList()
        .ForEach(e => {
          if (e is IOwnedBy<int> ownedEntity) {
            ownedEntity.UserId = _userId;
          }
        });
      return base.SaveChanges();
    }

  }

}