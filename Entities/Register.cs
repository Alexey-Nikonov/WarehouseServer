using System.ComponentModel.DataAnnotations;

namespace WarehouseServer.Entities
{
  public class Register : Login
  {
    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }
  }
}
