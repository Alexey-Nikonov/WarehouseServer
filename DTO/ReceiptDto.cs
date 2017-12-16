using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseServer.DTO
{
  [Table("receipts")]
  public class ReceiptDto : BaseModelDto
  {
    [Required]
    [Column("date")]
    public string Date { get; set; }

    [Range(1, 100000)]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("good_id")]
    public int GoodId { get; set; }
    public GoodDto Good { get; set; }
  }
}