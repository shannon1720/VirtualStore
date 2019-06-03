using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAcess.Crud
{
    public class ProductCrudFactory : CrudFactory
    {
        ProductMapper mapper;

        public ProductCrudFactory() : base()

        {
            mapper = new ProductMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var proyect = (Product)entity;
            var sqlOperation = mapper.GetCreateStatement(proyect);
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
            var listProyects = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
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

        public override void Update(BaseEntity entity)
        {
            var product = (Product)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(product));
        }

        public override void Delete(BaseEntity entity)
        {
            var product = (Product)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(product));
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

    }
}
