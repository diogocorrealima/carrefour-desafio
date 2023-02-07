using Microsoft.Extensions.Configuration;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Infra.Data
{
    public class SalesRepository : Repository<Sales>, ISalesRepository
    {
        public SalesRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
