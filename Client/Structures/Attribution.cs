using System.Collections.Generic;

namespace OpenOsp.Client.Structures {
  public struct Attribution {
    public KeyValuePair<string, string> Title { get; set; }
    
    public KeyValuePair<string, string> Author { get; set; }
    
    public KeyValuePair<string, string> License { get; set; }
  }
}