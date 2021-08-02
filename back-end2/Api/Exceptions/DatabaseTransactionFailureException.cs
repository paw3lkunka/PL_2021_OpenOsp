using System;

namespace OpenOsp.Api.Exceptions {

  public class DatabaseTransactionFailureException : Exception {

    public DatabaseTransactionFailureException() : base() {
    }

    public DatabaseTransactionFailureException(string message) : base(message) {
    }

  }

}