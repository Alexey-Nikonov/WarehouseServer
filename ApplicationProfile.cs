using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WarehouseServer.Entities;
using WarehouseServer.DTO;

namespace WarehouseServer
{
  public class ApplicationProfile : Profile
  {
    public ApplicationProfile()
    {
      CreateMap<Client, ClientDto>().ReverseMap();
      CreateMap<Good, GoodDto>().ReverseMap();
      CreateMap<Provider, ProviderDto>().ReverseMap();
      CreateMap<Realization, RealizationDto>().ReverseMap();
      CreateMap<Receipt, ReceiptDto>().ReverseMap();
      CreateMap<Table, TableDto>().ReverseMap();
      CreateMap<User, UserDto>().ReverseMap();
    }
  }
}
