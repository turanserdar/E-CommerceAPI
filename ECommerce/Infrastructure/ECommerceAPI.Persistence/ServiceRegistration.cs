using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {


        public static void AddPersistanceServices(this IServiceCollection services)
        {

            //Burada options. dedikten sonra Use diyip hangi veri tabanini kullanacaksak onunla ilgili kutuphaneyi yuklememiz gerekiyor. Managet Nuget diyoruz Persistence uzerinde ve Npgsql.EntityFrameworkCore.PostgreSQL bu kutuphaneyi yukluyorum. Ve yukarida sonrasinda mutlaka using Microsoft.EntityFrameworkCore; diyip namespacei eklememiz gerek.
            //Icine Connection String yaziyoruz. Connectionstrings.com da var
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));



    }

    }


}

    
