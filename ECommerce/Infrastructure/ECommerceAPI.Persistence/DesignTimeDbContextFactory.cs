using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    //Bunu yazmamizin nedeni Eger powershellden veya cmd den migration cikmaya calisirsak DbContextten gonderdigimiz  ECommerceAPIDbContext(DbContextOptions options) : base(options) bu degerlerden dolayi migration cikamiyor ve DesignTime hatasi veriyor o yuzden bu sekilde yaziyoruz. Sonrasinda interfacei de implemente ediyoruz
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDbContext>
    {
        public ECommerceAPIDbContext CreateDbContext(string[] args)
        {
    

            DbContextOptionsBuilder<ECommerceAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

            return new (dbContextOptionsBuilder.Options);
        }
    }
}
