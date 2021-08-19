using System;
using System.Linq;
using System.Collections.Generic;
using OpenOsp.Server.Enums;

namespace OpenOsp.Server.Exceptions {

  public class DbTransactionException : Exception {

    public DbTransactionException() : base() {
    }

    public DbTransactionException(string message) : base(message) {
    }

    public DbTransactionException(DbTransactionType type, string entityName, int rows, List<string> errors) 
      : this(CreateMessage(type, entityName, rows, errors)) {
    }

    public DbTransactionException(DbTransactionType type, string entityName, int rows) 
      : this(type, entityName, rows, null) {
    }

    private static string CreateMessage(DbTransactionType type, string entityName, int rows) {
      var message = $"Could not ";
      switch(type) {
        case DbTransactionType.None:
          message += "process";
          break;
        case DbTransactionType.Create:
          message += "create";
          break;
        case DbTransactionType.Read:
          message += "read";
          break;
        case DbTransactionType.Update:
          message += "update";
          break;
        case DbTransactionType.Delete:
          message += "delete";
          break;
      }
      message += $" {((rows > 1) ? rows : "the")} {(entityName == null ? "" : entityName + " ")}{((rows > 1) ? "entities" : "entity")}";
      return message + " due to the database transaction failure.";
    }

    private static string CreateMessage(DbTransactionType type, string entityName, int rows, List<string> errors) {
      var message = $"{CreateMessage(type, entityName, rows)} Errors: ";
      errors?.ForEach(e => message += $"\n\t{e}");
      return message;
    }

  }

  public class DbTransactionException<T> : DbTransactionException {

    public DbTransactionException(DbTransactionType type, int rows, List<string> errors)
      : base(type, typeof(T).Name, rows, errors) {
    }

    public DbTransactionException(DbTransactionType type, int rows)
      : this(type, rows, null) {
    }

    public DbTransactionException(DbTransactionType type, List<string> errors) 
      : this(type, 1, errors) {
    }

    public DbTransactionException(DbTransactionType type) 
      : this(type, 1) {
    }

    public DbTransactionException(List<string> errors) 
      : this(DbTransactionType.None, 1, errors) {
    }

    public DbTransactionException() 
      : this(DbTransactionType.None, 1) {
    }

  }

}