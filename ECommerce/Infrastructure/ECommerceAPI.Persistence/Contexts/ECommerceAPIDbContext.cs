using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        //Sayfanin bos olan bu kismina ctrl . diyerek generate constructor diyip asagidaki yapiyi olusturuyorum. Cunku Ioc containera biz bu DbContexti verecegiz ordan talep ederken belirli ayarlarda gelmesini istiyorsak bu ayarlarin Constructorda bildirilmesi gerekiyor.
        //Asagidaki gibi DbContextOptions parametresi alan ve bu parametreyi base e gonderen bir constructor aliyorum.Bu constructor Ioc containerda doldurulacak. 
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        //Buradaki yapiyi Prensentation katmanindaki Ioc i conteinera gondermemiz gerekiyor.Bunun icinde ServiceRegistration sinifini kullaniyoruz
    }
}
