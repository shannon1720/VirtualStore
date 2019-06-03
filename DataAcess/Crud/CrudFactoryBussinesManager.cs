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
    public class CrudFactoryBussinesManager : CrudFactory
    {
        private BussinessManagerMapper mapper;

        public CrudFactoryBussinesManager() : base()
        {
            mapper = new BussinessManagerMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var bussines = (BussinesManager)entity;
            var sqlOperation = mapper.GetCreateStatement(bussines);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var bussines = (BussinesManager)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(bussines));
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstBussines = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstBussines.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstBussines;
        }

        public override void Update(BaseEntity entity)
        {
            var bussines = (BussinesManager)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(bussines));
        }

    }
}
