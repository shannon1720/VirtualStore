using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class CartMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_EMAIL = "ID_USER";
        private const string DB_COL_ID_PRODUCT = "ID_PRODUCT";
        private const string DB_COL_QUANTITY = "QUANTITY";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

        var cart = new Cart
            {
                Id = GetIntValue(row, DB_COL_ID),
                Email = GetStringValue(row, DB_COL_EMAIL),
                IdProduct = GetIntValue(row, DB_COL_ID_PRODUCT),
                Quantity = GetIntValue(row, DB_COL_QUANTITY),
                Active = GetBooleanValue(row, DB_COL_ACTIVE)

            };

            return cart;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var carts = BuildObject(row);
                lstResults.Add(carts);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CART_PR" };

            var c = (Cart)entity;

          
            operation.AddIntParam(DB_COL_ID_PRODUCT, c.IdProduct);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddIntParam(DB_COL_QUANTITY, c.Quantity);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CART_PR" };
            var c = (Cart)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }
        
        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CART_PR" };
            var c = (Cart)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
