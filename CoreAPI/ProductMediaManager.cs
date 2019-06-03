using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ProductMediaManager : BaseManager
    {
        private ProductMediaCrudFactory crudProductMedia;

        public ProductMediaManager()
        {
            crudProductMedia = new ProductMediaCrudFactory();
        }

        public void Create(ProductMedia productMedia)
        {

            crudProductMedia.Create(productMedia);

        }

        public ProductMedia RetrieveById(ProductMedia productMedia)
        {
            ProductMedia p = null;
            try
            {
                p = crudProductMedia.Retrieve<ProductMedia>(productMedia);
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


        public void Update(ProductMedia ProductMedia)
        {
            crudProductMedia.Update(ProductMedia);
        }

    }
}
