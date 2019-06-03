using System;
using System.Collections.Generic;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcess.Crud
{
    public class ProductMediaCrudFactory : CrudFactory
    {
         ProductMediaMapper mapper;

        public ProductMediaCrudFactory() : base()
        {
            mapper = new ProductMediaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var productMedia = (ProductMedia)entity;
            var sqlOperation = mapper.GetCreateStatement(productMedia);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var productMedia = (ProductMedia)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(productMedia));
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

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
