using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Table : BaseModel
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Route { get; set; }

    [Required]
    public string Description { get; set; }
  }
}
