using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
     public  class CartManager
    {
        private CartCrudFactory crudProduct;

        public CartManager()
        {
            crudProduct = new CartCrudFactory();
        }

        public void Create(Cart cart)
        {

            crudProduct.Create(cart);

        }

        public void Delete(Cart cart)
        {
            crudProduct.Delete(cart);
        }

        public List<Cart> RetrieveByEmail(Cart cart)
        {
            return crudProduct.RetrieveByEmail<Cart>(cart);
        }

    }
}
