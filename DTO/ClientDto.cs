using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WarehouseServer.DTO
{
    [Table("clients")]
    public class ClientDto : BaseModelDto
    {
        [Required]
        [StringLength(70, MinimumLength = 3)]
        [Column("fio")]
        public string FIO { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Column("address")]
        public string Address { get; set; }

        [Phone]
        [Column("phone")]
        public string Phone { get; set; }        

        public List<RealizationDto> Realizations { get; set; }
    }
}