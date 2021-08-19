using System;

namespace OpenOsp.Api.Exceptions {

  public class ValidationProblemException : Exception {

    public ValidationProblemException() : base() {
    }

    public ValidationProblemException(string message) : base(message) {
    }

  }

}