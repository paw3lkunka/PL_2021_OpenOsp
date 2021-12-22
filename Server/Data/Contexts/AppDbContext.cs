using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;
using OpenOsp.Server.Data.Configurations;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Data.Contexts; 

public class AppDbContext : IdentityUserContext<User, int> {
  private readonly int _userId;

  public AppDbContext() { }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public AppDbContext(
    DbContextOptions<AppDbContext> options,
    IUserClaimsService<int> userClaims)
    : base(options) {
    _userId = userClaims.UserId;
  }

  public virtual DbSet<Action> Actions { get; set; }

  public virtual DbSet<ActionEquipment> ActionEquipment { get; set; }

  public virtual DbSet<ActionMember> ActionMembers { get; set; }

  public virtual DbSet<Equipment> Equipment { get; set; }

  public virtual DbSet<Member> Members { get; set; }

  public override DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);
    IEnumerable<IEntityConfiguration> entityConfigurations = new List<IEntityConfiguration> {
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

    builder.Entity<Action>()
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

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
    var addedOwnedEntities = ChangeTracker.Entries()
      .Where(e => e.State.Equals(EntityState.Added) && e.Entity is IOwnedBy<int>)
      .Select(e => e.Entity as IOwnedBy<int>)
      .ToList();
    if (addedOwnedEntities.Count > 0 && _userId == default) {
      throw new UnauthorizedException();
    }

    addedOwnedEntities.ForEach(e => e.UserId = _userId);
    return await base.SaveChangesAsync(cancellationToken);
  }
}