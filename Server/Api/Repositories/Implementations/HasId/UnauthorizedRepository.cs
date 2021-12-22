using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories; 

public class UnauthorizedRepository<T> : Repository<T>
  where T : class {
  public UnauthorizedRepository(AppDbContext context) : base(context) {
  }

  public override IQueryable<T> ReadAll() {
    return base.ReadAll().IgnoreQueryFilters();
  }
}

public class UnauthorizedRepository<T, TId> : HasIdRepository<T, TId>
  where T : class, IHasId<TId>
  where TId : IEquatable<TId>, IComparable<TId> {
  public UnauthorizedRepository(AppDbContext context) : base(context) {
  }

  public override IQueryable<T> ReadAll() {
    return base.ReadAll().IgnoreQueryFilters();
  }
}

public class UnauthorizedRepository<T, TId, TId2> : HasIdRepository<T, TId, TId2>
  where T : class, IHasId<TId, TId2>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2> {
  public UnauthorizedRepository(AppDbContext context) : base(context) {
  }

  public override IQueryable<T> ReadAll() {
    return base.ReadAll().IgnoreQueryFilters();
  }
}

public class UnauthorizedRepository<T, TId, TId2, TId3> : HasIdRepository<T, TId, TId2, TId3>
  where T : class, IHasId<TId, TId2, TId3>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2>
  where TId3 : IEquatable<TId3>, IComparable<TId3> {
  public UnauthorizedRepository(AppDbContext context) : base(context) {
  }

  public override IQueryable<T> ReadAll() {
    return base.ReadAll().IgnoreQueryFilters();
  }
}