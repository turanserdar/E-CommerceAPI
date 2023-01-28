using ECommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Customer:BaseEntity
    {


        public string Name { get; set; }


        #region Relations
        public ICollection<Order> Orders { get; set; }
        #endregion


    }
}
