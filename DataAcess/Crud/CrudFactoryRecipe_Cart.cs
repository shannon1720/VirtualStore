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
    public class CrudFactoryRecipe_Cart:CrudFactory
    {

        Recipe_CartMapper mapper;
        public CrudFactoryRecipe_Cart()
        {
            mapper = new Recipe_CartMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var recipe = (Recipe_Cart)entity;
            var sqlOperation = mapper.GetCreateStatement(recipe);
            dao.ExecuteProcedure(sqlOperation);
        }

     

        public override void Delete(BaseEntity entity)
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
