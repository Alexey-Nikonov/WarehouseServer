using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Receipt : BaseModel
  {
    [Required]
    public string Date { get; set; }

    [Range(1, 100000)]
    public int Quantity { get; set; }
    
    public int GoodId { get; set; }
  }
}
