using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {

        /*Burada dikkat edilmesi gerekenler:
         * Dependency injection ile CustomerReadRepository talep ederken ICustomerReadRepository ile talep edecegiz. Cunku bunun soyut yapilanmasi ICustomerReadRepository
        
        */

        public CustomerReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
