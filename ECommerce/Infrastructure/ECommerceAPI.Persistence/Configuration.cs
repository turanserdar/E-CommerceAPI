using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    static class Configuration
    {
        //Connectionstringi bu sinifin icinde cagiriyoruz
            static public string ConnectionString
        {


            get
            {

                ConfigurationManager configurationManager = new(); //Microsoft.Extensions.Configuration kutuphanesini yuklemek zorundayiz kullanabilmek icin

                //Asagida yazacagimiz iki fonksiyonu da elde edebilmek icin yine nuget managerdan Microsoft.Extensions.Configuration.Json bu kutuphaneyi yukluyoruz
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceAPI.API")); //appsettings.jsonin oldugu yerin konumunu verdik
                configurationManager.AddJsonFile("appsettings.json");


                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }

    }
}
