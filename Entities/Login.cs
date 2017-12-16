using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Login : BaseModel
  {
    [Required(ErrorMessage = "Не указан логин")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}