using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Crud
{
    public class ClientCrudFactory : CrudFactory
    {
        ClientMapper mapper;

        public ClientCrudFactory() : base()

        {
            mapper = new ClientMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var client = (Client)entity;
            var sqlOperation = mapper.GetCreateStatement(client);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByEmailStatement(entity));
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
            var listClient = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listClient.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listClient;
        }

        public override void Update(BaseEntity entity)
        {
            var client = (Client)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(client));
        }

        public override void Delete(BaseEntity entity)
        {
            var client = (Client)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(client));
        }

        public  List<T> RetrieveByEmail<T>(BaseEntity entity)
        {
            var listClient = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByEmailStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listClient.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listClient;
        }

        public List<T> RetrieveByState<T>(BaseEntity entity)
        {
            var listProyects = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByStateStatement(entity));
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

    }
}
