using SphereAPI.Data;
using SphereAPI.IRepository;
using SphereAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SphereAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IGenericRepository<AppUser> _users;
        private IGenericRepository<Product> _products;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public IGenericRepository<AppUser> AppUsers => _users ??= new GenericRepository<AppUser>(context);

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(context);

       

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
