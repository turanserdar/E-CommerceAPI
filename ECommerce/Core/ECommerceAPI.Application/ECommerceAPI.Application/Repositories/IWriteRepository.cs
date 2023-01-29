using ECommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    // Insert, Update ve Delete islemleri tanimlanacak
    public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
    {
        //Asagidaki fonksiyonlara bool verdik cunku eklediyek sonucu true ya da false donecegiz 
        Task<bool> AddAsync(T model); // Bu bir tane ekleyecek olursak kullaniyoruz

        Task<bool> AddRangeAsync(List<T> datas); // Gelen koleksiyonu veri tabanina eklemek istersek bunu kullanacagiz

        Task<bool> RemoveAsync(string id);

        bool Remove(T model);

        bool RemoveRange(List<T> datas);

        bool Update(T model);

        Task<int> SaveAsync();


    }
}
