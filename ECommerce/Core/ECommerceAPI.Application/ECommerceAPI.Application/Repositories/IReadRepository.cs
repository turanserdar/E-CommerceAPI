using ECommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    //Bunun icerisine Read ile ilgili islemler tanimlanacak
    //If you are going to obtain data from a database as a result of query operations, we will call it Read operations./SELECT/
    public interface IReadRepository<T> : IRepository<T> where T:BaseEntity
    {
        //Asagidaki fonksiyonlardan bir kismi asenkron fonksiyonlari kullanacak.Peki hangileri asenkro fonksiyonlari kullanacak.GetSingle firstordefaultun asenkron fonksiyonunu kullanacak . Bundan dolayi bunlarin isminin sonuna Async keywordu eklenir. Ve Task<> olarak data gonderilir 
       



        //IQueryable ve INumarable var. Sorgu uzerinde calismak istiyorsak IQueryable.I Numarable ise memory(bellek) üzerinde muhafıza edilen veriler üzerinden gerekli sorgulama işlemleri yapar.
        ////There are IQueryable and INumarable. If we want to work on the query, IQueryable.INumarable makes the necessary query operations over the data stored on memory.
        //Burada List tarzi seyler kullanmayin. List INumerable dir memorye ceker verileri onun uzerinde islem  yapmamizi saglar.IQueryable de yazilan sorgular ilgili veritabani sorgularina eklenecektir
        IQueryable<T> GetAll(bool tracking = true); 


        //Burada paranetez icinde yazdigim ifade verdigim sarta uygun ifadeleri getir demek
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method, bool tracking = true);

        //Vermis oldugum sarta uygun ilk tekil nesneyi getirecek bir sorgu olusturacaksak cogul ifade olan IQuerayable i vs kullanmiyorum
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method,bool tracking = true); //Burada da sarta uygun olan ilkini getirecek

        Task<T> GetByIdAsync(string id,bool tracking = true);

    }
}
