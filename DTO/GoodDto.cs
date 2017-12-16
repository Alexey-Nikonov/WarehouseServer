using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WarehouseServer.DTO
{
  [Table("goods")]
  public class GoodDto : BaseModelDto
  {
    [Required]
    [StringLength(40, MinimumLength = 3)]
    [Column("name")]
    public string Name { get; set; }

    [Range(1, 1000000)]
    [Column("price")]
    public int? Price { get; set; }

    [Column("provider_id")]
    public int ProviderId { get; set; }
    public ProviderDto Provider { get; set; }

    public List<ReceiptDto> Receipts { get; set; }

    public List<RealizationDto> Realizations { get; set; }
  }
}