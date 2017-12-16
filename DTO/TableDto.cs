using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseServer.DTO
{
  [Table("tables")]
  public class TableDto : BaseModelDto
  {
    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [Column("route")]
    public string Route { get; set; }

    [Required]
    [Column("description")]
    public string Description { get; set; }
  }
}