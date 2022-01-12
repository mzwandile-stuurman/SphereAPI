using Microsoft.EntityFrameworkCore;
using SphereAPI.Data;
using SphereAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SphereAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> db;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;

            db = this.context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = db;
            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetT(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = db;
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T entity)
        {
            await db.AddAsync(entity);
        }

        public void Update(T entity)
        {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        //public async Task Delete(int id)
        //{
        //var entity = await db.FindAsync(id);
        //db.Re
        //}

    }
}
