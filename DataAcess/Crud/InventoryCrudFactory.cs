using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Crud
{
    public class InventoryCrudFactory : CrudFactory
    {
        InventoryMapper mapper;
        ProductMapper productMapper;

        public InventoryCrudFactory() : base()
        {
            mapper = new InventoryMapper();
            productMapper = new ProductMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var deliver = (Inventory)entity;
            var sqlOperation = mapper.GetCreateStatement(deliver);

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
            var deliver = (Inventory)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(deliver));
        }

        public override void Delete(BaseEntity entity)
        {
            var deliver = (Inventory)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(deliver));
        }

        public List<Product> RetrieveAllByCellar<T>(BaseEntity entity)
        {
            var listDelivers = new List<Product>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveProductByCellarStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = productMapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listDelivers.Add((Product)Convert.ChangeType(c, typeof(Product)));
                }
            }

            return listDelivers;
        }
    }
}
