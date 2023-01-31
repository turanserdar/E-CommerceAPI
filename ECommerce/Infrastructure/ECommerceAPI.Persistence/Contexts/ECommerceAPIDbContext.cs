using ECommerceAPI.Domain.Common;
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

        //Asagida yazdigim override=interceptor yani bundan sonra her savechanges tetiklendiginde ben insert ile update yapilan tum datalari elde edip istedigim  degisikligi yapip SaveChangesAsynci devreye sokabilirim.Bunun icin ChageTracker denilen bir property var DBContext sayesinde eriyoruz
        
        /* ChangeTracker is a feature in ASP.NET Core that enables you to keep track of changes made to entities in a Entity Framework Core context. It is part of the Microsoft.EntityFrameworkCore namespace.

          The ChangeTracker monitors changes made to entities and keeps track of these changes so that you can persist them to a database using the SaveChanges method. The ChangeTracker also provides information about the state of entities in the context, such as whether they have been added, modified, or deleted. */
        //Change Tracker entityler uzerinden yapilan degisikliklerin ya da yeni eklenen verinin yakalanmasini saglayan propertydir.Update operasyonlarinda Track edilen verileri yakalayip elde etmenizi saglar.Update edilen bir nesne track edildiginde yakalanir ama Insert edilen nesne contexten gelmedigi icin yakalanmaz.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Entiries ile surece giren butun girdileri getiriyoruz.Asagida yazdigimiz kodla surece giren butun base entityleri yakala diyoruz


            var datas = ChangeTracker
                  .Entries<BaseEntity>();

            foreach (var data in datas)
            {

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate=DateTime.UtcNow

                };

            }



            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
