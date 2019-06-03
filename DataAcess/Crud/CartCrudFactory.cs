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
    public class CartCrudFactory : CrudFactory
    {

        CartMapper mapper;

        public CartCrudFactory()
        {
            mapper = new CartMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var cart = (Cart)entity;
            var sqlOperation = mapper.GetCreateStatement(cart);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var cart = (Cart)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(cart));
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

        public List<T> RetrieveByEmail<T>(BaseEntity entity)
        {
            var lstCategory = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
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

    }


}
