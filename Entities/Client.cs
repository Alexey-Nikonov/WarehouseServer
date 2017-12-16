namespace WarehouseServer.Entities
{
  public class Client : BaseModel
  {
    public string FIO { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
  }
}
