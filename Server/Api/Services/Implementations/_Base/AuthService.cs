using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenOsp.Server.Exceptions;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Api.Services {

  public class AuthService<T, TId>
    : HasIdService<T, TId>
    where T : class, IHasId<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    public AuthService(AppDbContext context) : base(context) {
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return await _context.Set<T>()
        .ToListAsync();
    }

    public override async Task<T> ReadById(TId id) {
      try {
        var entity = await _context.Set<T>()
          .FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (entity == default(T)) {
          throw new UnauthorizedException();
        }
        return entity;
      }
      catch (UnauthorizedException) {
        await base.ReadById(id);
        throw;
      }
    }

  }

  public class AuthService<T, TId1, TId2>
    : HasIdService<T, TId1, TId2>
    where T : class, IHasId<TId1, TId2>
    where TId1 : IEquatable<TId1>, IComparable<TId1>, IConvertible
    where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible {

    public AuthService(AppDbContext context) : base(context) {
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return await _context.Set<T>()
        .ToListAsync();
    }

    public override async Task<T> ReadById(TId1 id1, TId2 id2) {
      try {
        var entity = await _context.Set<T>()
          .FirstOrDefaultAsync(e =>
            e.Id1.Equals(id1)
            && e.Id2.Equals(id2)
          );
        if (entity == default(T)) {
          throw new UnauthorizedException();
        }
        return entity;
      }
      catch (UnauthorizedException) {
        await base.ReadById(id1, id2);
        throw;
      }
    }

  }

  public class AuthService<T, TId1, TId2, TId3>
    : HasIdService<T, TId1, TId2, TId3>
    where T : class, IHasId<TId1, TId2, TId3>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    public AuthService(AppDbContext context) : base(context) {
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return await _context.Set<T>()
        .ToListAsync();
    }

    public override async Task<T> ReadById(TId1 id1, TId2 id2, TId3 id3) {
      try {
        var entity = await _context.Set<T>()
          .FirstOrDefaultAsync(e =>
            e.Id1.Equals(id1)
            && e.Id2.Equals(id2)
            && e.Id3.Equals(id3)
          );
        if (entity == default(T)) {
          throw new UnauthorizedException();
        }
        return entity;
      }
      catch (UnauthorizedException) {
        await base.ReadById(id1, id2, id3);
        throw;
      }
    }

  }

}