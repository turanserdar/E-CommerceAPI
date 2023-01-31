using ECommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Product:BaseEntity
    {

        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }


        #region Relations
        
        public ICollection<Order> Orders { get; set; }




        #endregion


    }
}
