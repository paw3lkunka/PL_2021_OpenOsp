using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenOsp.Model.Models;
using OpenOsp.Data.Configurations;

namespace OpenOsp.Data.Contexts {

  public class AppDbContext<TUserKey> : IdentityUserContext<User, TUserKey> 
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible {

    public AppDbContext() : base() { }

    public AppDbContext(
      DbContextOptions<AppDbContext> options,
      IUserClaimsService<TUserKey> userClaims) 
      : base(options) { 
      _userKey = userClaims.UserKey;
    }

    private readonly TUserKey _userKey;

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
      modelBuilder.Entity<Action>()
        .HasQueryFilter(e => e.UserKey.Equals(_userKey));
      modelBuilder.Entity<Equipment>()
        .HasQueryFilter(e => e.UserKey.Equals(_userKey));
      modelBuilder.Entity<Member>()
        .HasQueryFilter(e => e.UserKey.Equals(_userKey));
      modelBuilder.Entity<ActionEquipment>()
        .HasQueryFilter(e => e.Action.UserKey.Equals(_userKey));
      modelBuilder.Entity<ActionMember>()
        .HasQueryFilter(e => e.Action.UserKey.Equals(_userKey));
    }

    public override int SaveChanges() {
      ChangeTracker.Entries()
        .Where(e => e.State.Equals(EntityState.Added))
        .ForEach(e => {
          if(e is IOwnedBy ownedEntity) {
            ownedEntity.UserKey = _userKey;
          }
        });
      return base.SaveChanges();
    }

  }

}