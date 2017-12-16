using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Realization : BaseModel
  {
    [Required]
    public string Date { get; set; }

    [Range(1, 100000)]
    public int Quantity { get; set; }

    public int ClientId { get; set; }

    public int GoodId { get; set; }
  }
}
