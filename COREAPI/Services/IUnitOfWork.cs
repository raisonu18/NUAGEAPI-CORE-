using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Dispose();
        IRepository<T> Get<T>() where T : class;
    }
}
