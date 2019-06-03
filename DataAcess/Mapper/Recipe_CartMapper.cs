using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
     public  class Recipe_CartMapper : EntityMapper, ISqlStaments, IObjectMapper
    {



        private const string DB_COL_ID = "ID";
        private const string DB_COL_RECIPE = "RECIPE";
        private const string DB_COL_ID_CART = "ID_CART";
       
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new System.NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_RECIPE_CART_PR" };

            var c = (Recipe_Cart)entity;
            
            operation.AddIntParam(DB_COL_RECIPE, c.Id_Recipe);
            operation.AddIntParam(DB_COL_ID_CART, c.Id_Cart);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
