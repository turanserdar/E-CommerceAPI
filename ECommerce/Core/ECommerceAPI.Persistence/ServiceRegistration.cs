using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistence.Concretes;
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
        //Burada bu extension fonksiyonu tanimliyoruz.Extension fonksiyonlar statik fonksiyonlardir//Ileri duzey bir konudur. Bu fonksiyonu IoC Conteinera ekleyecegiz.Yani Program.cs icerisinde IservicesCollectiona. Bunun icin this IserviceCollection diyoruz.Sonra buna services.Add diyip istedigimiz servicelere erisebiliyoruz

            public static void AddPersistenceServices(this IServiceCollection services)
        {
            //Asagida yazdigim kod ile IProductService talebi geldiginde bana ProductServicei gonder diyorum.Bunu Persistence icerisinde sagladim.Her bir service sinifi kullanabilmem icin buradaki extension metot yeterli olacaktir.Ama bu yeterli degil.Bu extension code Ioc container barindiran Presantation katmani tarafindan cagirilmasi gerekiyor
            services.AddSingleton<IProductService, ProductService>();

            //Ekledigimiz bu service i Program.cs de build.Services.AddPersistenceServices() diyerek cagiriyorum.Bu sekilde persistence katmani icindeki butun serviceleri Ioc containera ekliyoruz


        }

    }

}
 
     