using System;

namespace OpenOsp.Server.Exceptions; 

public class UnauthorizedException : Exception {
  public UnauthorizedException() {
  }

  public UnauthorizedException(string message) : base(message) {
  }
}