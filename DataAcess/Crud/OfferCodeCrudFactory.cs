using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Dao;
using DataAcess.Mapper;

namespace DataAcess.Crud
{
    public class OfferCodeCrudFactory : CrudFactory
    {
        OfferCodeMapper mapper;

        public OfferCodeCrudFactory() : base()

        {
            mapper = new OfferCodeMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var offerCode = (OfferCode)entity;
            var sqlOperation = mapper.GetCreateStatement(offerCode);
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
            var listOfferCode = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listOfferCode.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listOfferCode;
        }

        public override void Update(BaseEntity entity)
        {
            var oferCode = (OfferCode)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(oferCode));
        }

        public override void Delete(BaseEntity entity)
        {
            var product = (OfferCode)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(product));
        }

        public List<T> RetrieveByState<T>(BaseEntity entity)
        {
            var listOfferCode = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByStateStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listOfferCode.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listOfferCode;
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
