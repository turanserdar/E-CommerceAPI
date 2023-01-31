using ECommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        //We deliberately set this CustomerId. Because we have defined a customer relationship below. Therefore, if we do not specify the Customer Id ourselves, Entity Framework will set it automatically. We wanted to determine here.
        public Guid CustomerId { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }


        #region Relations

        
        // There is a 1-n relationship between order and product .We reference a collection to the many-to-one. We reference the Property with the ICollection. This means that an order has more than one product. If we write the same as below for order in Product class. Each product would have had more than one order and there would be an n-n relationship.
        public ICollection<Product> Products { get; set; }


        //An order has more than one product but only one Customer.

        public Customer Customer { get; set; }
        #endregion

    }
}
