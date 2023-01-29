using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //Bu repositorynin Db Setini cagirdik

     

        public async Task<bool> AddAsync(T model)
        { EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
           await Table.AddRangeAsync(datas);
            return true;
        }


        //public async Task<bool> AddRangeAsync(List<T> model)

        //{ return model; }



        //await ve async yapilari task donen fonksiyonlarda kullanilir
        public async Task<bool> RemoveAsync(string id)
        {

            T model = await Table.FirstOrDefaultAsync(data=>data.id==Guid.Parse(id));
            return Remove(model);

        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true; 
        }

        public async Task<int> SaveAsync()

            => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
           EntityEntry entityEntry= Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
