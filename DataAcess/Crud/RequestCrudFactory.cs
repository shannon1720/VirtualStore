using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Crud
{
    public class RequestCrudFactory : CrudFactory
    {
        private RequestMapper mapper;

        public RequestCrudFactory() : base()
        {
            mapper = new RequestMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var request = (Request)entity;
            var sqlOperation = mapper.GetCreateStatement(request);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var request = (Request)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(request));
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
            var lstRequest = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstRequest.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstRequest;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public  List<T> RetrieveByEmail<T>(BaseEntity entity)
        {
            var lstRequest = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByEmailStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstRequest.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstRequest;
        }
    }
}
