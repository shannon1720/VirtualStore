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
    public class CategoryCrudFactory : CrudFactory
    {
        CategoryMapper mapper;

        public CategoryCrudFactory()
        {
            mapper = new CategoryMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var category = (Category)entity;
            var sqlOperation = mapper.GetCreateStatement(category);
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
            var lstCategory = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var category = mapper.BuildObjects(lstResult);
                foreach (var c in category)
                {
                    lstCategory.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCategory;
        }

        public override void Update(BaseEntity entity)
        {
            var category = (Category)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(category));
        }

        public override void Delete(BaseEntity entity)
        {
            var category = (Category)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(category));
        }

        public List<T> RetrieveByState<T>(BaseEntity entity)
        {
            var lstCategory = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByStateStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCategory.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCategory;
        }

        public T RetrieveByName2<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementName(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
    }
}