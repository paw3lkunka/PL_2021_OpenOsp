using System;

namespace OpenOsp.WebApi.Exceptions {

  public class ValidationProblemException : Exception {

    public ValidationProblemException() : base() {
    }

    public ValidationProblemException(string? message) : base(message) {
    }

  }

}