﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseServer.DTO;

namespace WarehouseServer.Providers
{
  public class ReceiptRepository : Repository<ReceiptDto>, IReceiptRepository
  {
    public ReceiptRepository(EFContext context) : base(context) { }
    public EFContext Context
    {
      get { return this.context as EFContext; }
    }
  }
}
