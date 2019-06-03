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
    public class CellarManager : BaseManager
    {
        private CellarCrudFactory crudCellar;

        public CellarManager()
        {
            crudCellar = new CellarCrudFactory();
        }

        public void Create(Cellar cellar)
        {
            try
            {
               
                    crudCellar.Create(cellar);
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cellar> RetrieveAll()
        {
            return crudCellar.RetrieveAll<Cellar>();
        }

        public Cellar RetrieveById(Cellar cellar)
        {

            return crudCellar.Retrieve<Cellar>(cellar);
        }

        public void Update(Cellar cellar)
        {
            crudCellar.Update(cellar);
        }
    }
}
