using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseServer.DTO
{
  [Table("users")]
  public class UserDto : BaseModelDto
  {
    [Required(ErrorMessage = "Не указан логин")]
    [Column("username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    [Column("password")]
    public string Password { get; set; }

    [Required]
    [Column("role")]
    public string Role { get; set; }
  }
}
