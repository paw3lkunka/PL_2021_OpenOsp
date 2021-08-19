using System;

namespace OpenOsp.Server.Exceptions {

  public class ValidationProblemException : Exception {

    public ValidationProblemException() : base() {
    }

    public ValidationProblemException(string message) : base(message) {
    }

  }

}