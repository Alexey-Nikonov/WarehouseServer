using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseServer.DTO
{
  public abstract class BaseModelDto
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
  }
}