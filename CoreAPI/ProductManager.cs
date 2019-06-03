using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ProductManager : BaseManager
    {
        private ProductCrudFactory crudProduct;

        public ProductManager()
        {
            crudProduct = new ProductCrudFactory();
        }

        public void Create(Product product)
        {

            crudProduct.Create(product);

        }

        public Product RetrieveById(Product product)
        {
            Product p = null;
            try
            {
                p = crudProduct.Retrieve<Product>(product);
                if (p == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return p;
        }

        public List<Product> RetrieveAll()
        {
            
            var products = crudProduct.RetrieveAll<Product>();
            foreach (var product in products)
            {
                if (product.State == true)
                {
                    product.Active = "Activado";

                }
                else
                {
                    product.Active = "Desactivado";

                }
            }

            return products;
        }

        public List<Product> RetrieveByName(Product product)
        {
            return crudProduct.RetrieveByName<Product>(product);
        }

        public List<Product> RetrieveByState(Product product)
        {
            return crudProduct.RetrieveByState<Product>(product);
        }

        public void Update(Product product)
        {
            crudProduct.Update(product);
        }

        public void Delete(Product product)
        {
            crudProduct.Delete(product);
        }
    }
}
