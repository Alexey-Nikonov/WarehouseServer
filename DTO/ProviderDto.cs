using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WarehouseServer.DTO
{
  [Table("providers")]
  public class ProviderDto : BaseModelDto
  {
    [Required]
    [StringLength(40, MinimumLength = 3)]
    [Column("name")]
    public string Name { get; set; }

    [StringLength(100, MinimumLength = 3)]
    [Column("address")]
    public string Address { get; set; }

    [Phone]
    [Column("phone")]
    public string Phone { get; set; }

    public List<GoodDto> Goods { get; set; }
  }
}