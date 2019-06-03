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
    public class LocationManager : BaseManager
    {
        private LocationCrudFactory crudLocation;

        public LocationManager()
        {
            crudLocation = new LocationCrudFactory();
        }

        public void Create(Location location)
        {
            try
            {
                    crudLocation.Create(location);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Location> RetrieveAll()
        {
            return crudLocation.RetrieveAll<Location>();
        }

        public Location RetrieveById(Location location)
        {
            return crudLocation.Retrieve<Location>(location);
        }

        public void Update(Location location)
        {
            crudLocation.Update(location);
        }
    }
}
