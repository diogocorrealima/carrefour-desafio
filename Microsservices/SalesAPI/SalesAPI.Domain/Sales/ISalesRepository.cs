using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Interfaces;

namespace SalesAPI.Domain.Interfaces
{
    public interface ISalesRepository : IRepository<Sales>, IUnitOfWork
    {
    }
}