using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        //Burada ECommerceAPIDbContext nesnemizi Dependency Injection ile Ioc Container a koymustuk onun uzerinden talep edecegiz. Ve onun uzerinden gerekli read islemlerini gerceklestiriyor olacagiz. 

        private readonly ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

       

        public IQueryable<T> GetAll() //Get All ile veri tabaninda T turune uygun ne kadar veri varsa getir diyoruz
        => Table;


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)

            =>await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)

            => await Table.FirstOrDefaultAsync(data => data.id == Guid.Parse(id));
        //Stringi guide cevirdik

        

      
    }
}
