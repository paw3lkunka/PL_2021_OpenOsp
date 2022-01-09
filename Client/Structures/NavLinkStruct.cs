namespace OpenOsp.Client.Structures; 

public struct NavLinkStruct {
  public string Url { get; set; }

  public string Label { get; set; }

  public bool IsAvailable { get; set; }
  
  public bool IsAuthorized { get; set; }
}