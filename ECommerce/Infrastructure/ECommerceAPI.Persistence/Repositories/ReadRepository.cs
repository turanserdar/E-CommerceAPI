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



        public IQueryable<T> GetAll(bool tracking = true) //Get All ile veri tabaninda T turune uygun ne kadar veri varsa getir diyoruz

        {
            //AsQueryable, .NET Framework içindeki System.Linq namespace içindeki bir metoddur. Bu metod, verilen nesnenin IQueryable türüne dönüştürülmesini sağlar. Bu, LINQ (Language Integrated Query) sorguları tarafından desteklenen bir veri kaynağına dönüştürme yapmasını sağlar.AsQueryable metodu, verilen bir nesnenin IQueryable türüne dönüştürülmesini sağlar. LINQ sorguları, IQueryable türlerine uygulanabilir ve bu sorgular verileri çalışma zamanında değil, sorgu zamanında uygulanır. Bu, verilerin sorgulandıktan sonra verilmesini ve bellekte daha az yer kaplamasını sağlar. Yani asagida AsQuaryable yazmakla artik linq sorgularini query uzerinde uygulayabiliriz.

            var query = Table.AsQueryable();

            //tracking true ise zaten data track edilerek gelsin. Fakat sorgu false ise o zaman tracki kopariyoruz. Ilgili gelen datanin track edilmesini istemiyoruz
            //Eger track track istemiyorsak:

            if (!tracking)

                query = query.AsNoTracking(); //Burada devre disi biraktik


            return query;
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        //=> Table.Where(method);
        {
            var query = Table.Where(method);

            if (!tracking)
            { query = query.AsNoTracking();
            }


            return query;

        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)

         /*   =>await Table.FirstOrDefaultAsync(method)*/

        {

        var query = Table.AsQueryable();
        if (!tracking)
	{
                query = query.AsNoTracking();
	}

            return await query.FirstOrDefaultAsync(method);

        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)

        //=> await Table.FirstOrDefaultAsync(data => data.id == Guid.Parse(id));//Marker pattern, stringi guid e cevirdik
        //=> await Table.FindAsync(Guid.Parse(id));   //Ef find method  //IQuerayble da calisirken FindAsync fonksiyonu yoktur o yuzden Marker kullanmamiz lazim asagida return de kullandigimiz gibi

        {

            var query = Table.AsQueryable();

            if (!tracking)
    

                query=query.AsNoTracking();


            return await query.FirstOrDefaultAsync(data => data.id == Guid.Parse(id));


        }

        

      
    }
}
