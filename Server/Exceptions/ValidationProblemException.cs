using System;

namespace OpenOsp.Server.Exceptions; 

public class ValidationProblemException : Exception {
  public ValidationProblemException() {
  }

  public ValidationProblemException(string message) : base(message) {
  }
}