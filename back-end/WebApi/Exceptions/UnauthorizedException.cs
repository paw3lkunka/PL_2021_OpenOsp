using System;

namespace OpenOsp.WebApi.Exceptions {

  public class UnauthorizedException : Exception {

    public UnauthorizedException() : base() {
    }

    public UnauthorizedException(string? message) : base(message) {
    }

  }

}