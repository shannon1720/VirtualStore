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
    public class PreferenceCrudFactory : CrudFactory
    {
        private PreferenceMapper mapper;

        public PreferenceCrudFactory() : base()
        {
            mapper = new PreferenceMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var preference = (Preference)entity;
            var sqlOperation = mapper.GetCreateStatement(preference);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {

            var preference = (Preference)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(preference));
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
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var preference = (Preference)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(preference));
        }

    }
}
