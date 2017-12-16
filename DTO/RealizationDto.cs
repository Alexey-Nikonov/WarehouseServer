using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseServer.DTO
{
  [Table("realizations")]
  public class RealizationDto : BaseModelDto
  {
    [Required]
    [Column("date")]
    public string Date { get; set; }

    [Range(1, 100000)]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }
    public ClientDto Client { get; set; }

    [Column("good_id")]
    public int GoodId { get; set; }
    public GoodDto Good { get; set; }
  }
}