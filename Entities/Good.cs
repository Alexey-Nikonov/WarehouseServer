using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Good : BaseModel
  {
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(1, 1000000)]
    public int? Price { get; set; }

    public int ProviderId { get; set; }
  }
}
