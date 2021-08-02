using System;

namespace OpenOsp.Api.Exceptions {

  public class NotFoundException : Exception {

    public NotFoundException() : base() {
    }

    public NotFoundException(string message) : base(message) {
    }

  }

}