using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcess.Crud
{
    public class AdvertisingCrudFactory : CrudFactory
    {
        AdvertisingMapper mapper;

        public AdvertisingCrudFactory() : base()

        {
            mapper = new AdvertisingMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var listAds = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listAds.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listAds;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveByName<T>(BaseEntity entity)
        {
            var listProyects = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByNameStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listProyects.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listProyects;
        }

        public  List<T> RetrieveByState<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
