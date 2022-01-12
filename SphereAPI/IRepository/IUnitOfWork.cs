using SphereAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SphereAPI.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        Task Save();
        public IGenericRepository<AppUser> AppUsers { get; }
        public IGenericRepository<Product> Products { get; } 
    }
}
