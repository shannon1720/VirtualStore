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
    public class SellerStoreCrudFactory : CrudFactory
    {
        SellerStoreMapper mapper;

        public SellerStoreCrudFactory()
        {
            mapper = new SellerStoreMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var seller = (SellerStore)entity;
            var sqlOperation = mapper.GetCreateStatement(seller);
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
            var lstSellerStore = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var seller = mapper.BuildObjects(lstResult);
                foreach (var c in seller)
                {
                    lstSellerStore.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstSellerStore;
        }

        public override void Update(BaseEntity entity)
        {
            var seller = (SellerStore)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(seller));
        }

        public override void Delete(BaseEntity entity)
        {
            var seller = (SellerStore)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(seller));
        }

        public void UpdatePassword(BaseEntity entity)
        {
            var seller = (SellerStore)entity;
            dao.ExecuteProcedure(mapper.UpdPassword(seller));
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
