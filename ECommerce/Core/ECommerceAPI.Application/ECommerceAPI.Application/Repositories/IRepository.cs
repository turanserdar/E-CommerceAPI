using ECommerceAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{

    //Butun repositorylerin icerisinde ne olmasini istiyorsak onlari buraya koyuyoruz
    public interface IRepository<T> where T: BaseEntity
    {
        DbSet<T> Table { get; } // Tableimizi aliyoruz ama herhangi bir set islemiy yapmiyoruz


    }
}
