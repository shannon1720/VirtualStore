using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcess.Crud
{
    public class UserCodeCrudFactory : CrudFactory
    {
        UserCodeMapper mapper;

        public UserCodeCrudFactory()
        {
            mapper = new UserCodeMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Delete(BaseEntity entity)
        {
            var code = (UserCode)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(code));
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
