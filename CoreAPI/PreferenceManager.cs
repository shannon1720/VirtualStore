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
   
    public class PreferenceManager : BaseManager
    {
        private PreferenceCrudFactory crudPreference;

        public PreferenceManager()
        {
            crudPreference = new PreferenceCrudFactory();
        }

        public void Create(Preference preference)
        {
            try
            {
                crudPreference.Create(preference);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Preference Retrieve(Preference preference)
        {
            Preference i = null;

            try
            {
                i = crudPreference.Retrieve<Preference>(preference);

                if (i == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return i;
        }

        public void Update(Preference preference)
        {
            crudPreference.Update(preference);
        }

        public void Delete(Preference preference)
        {
            crudPreference.Delete(preference);
        }
    }
}
