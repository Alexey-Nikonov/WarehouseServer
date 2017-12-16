using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Provider : BaseModel
  {
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string Address { get; set; }

    [Phone]
    public string Phone { get; set; }
  }
}
