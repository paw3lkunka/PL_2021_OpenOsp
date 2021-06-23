using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {
  public abstract class DbModel {
    [Key]
    public int Id { get; set; }
  }
}