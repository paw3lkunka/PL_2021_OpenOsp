using System;

namespace OpenOsp.WebApi.Exceptions {
  public class DatabaseTransactionFailureException : Exception {
    public DatabaseTransactionFailureException() : base() {
    }

    public DatabaseTransactionFailureException(string? message) : base(message) {
    }
  }
}