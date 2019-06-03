using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CurrencyManager 
    {
        private CurrencyCrudFactory crudCurrency;

        public CurrencyManager()
        {
            crudCurrency = new CurrencyCrudFactory();
        }
        public List<Currency> RetrieveAll()
        {
            return crudCurrency.RetrieveAll<Currency>();
        }

    }
}
