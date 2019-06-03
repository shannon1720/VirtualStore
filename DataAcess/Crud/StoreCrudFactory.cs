using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Dao;
using DataAcess.Mapper;

namespace DataAcess.Crud
{
    public class StoreCrudFactory : CrudFactory
    {
        StoreMapper mapper;

        public StoreCrudFactory() : base()
        {
            mapper = new StoreMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var storeAdmin = (Store)entity;
            var sqlOperation = mapper.GetCreateStatement(storeAdmin);

            dao.ExecuteProcedure(sqlOperation);
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
            var listDelivers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listDelivers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listDelivers;
        }

        public override void Update(BaseEntity entity)
        {
            var storeAdmin = (Store)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(storeAdmin));
        }

        public override void Delete(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }

        public T RetrieveCellarId<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCellarIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveStoreByUserEmail<T>(BaseEntity entity)
        {
            var listDelivers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetStoreByUserStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listDelivers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listDelivers;
        }

        public List<T> RetrieveByState<T>(BaseEntity entity)
        {
            var lstSellerStore = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByStateStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstSellerStore.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstSellerStore;
        }

    }
}
