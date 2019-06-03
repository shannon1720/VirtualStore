using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Dao;

namespace DataAcess.Mapper
{
    public class AdvertisingMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_PRODUCT = "ID_PRODUCT";
        private const string DB_COL_PRODUCT = "PRODUCT";
        private const string DB_COL_ID_USER_PREFERENCES = "ID_USER_PREFERENCES";
        private const string DB_COL_USER = "USER";
        private const string DB_COL_PRICE = "PRICE_FINAL";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ads = new Advertising
            {
                IdProduct = GetIntValue(row, DB_COL_ID_PRODUCT),
                ProductName = GetStringValue(row, DB_COL_PRODUCT),
                IdUserPreferences = GetIntValue(row, DB_COL_ID_USER_PREFERENCES),
                Email = GetStringValue(row, DB_COL_USER),
                Price = GetDecimalValue(row, DB_COL_PRICE),
            };

            return ads;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ADVERTISING_PR" };

            var ads = (Advertising)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCT, ads.IdProduct);
            operation.AddVarcharParam(DB_COL_PRODUCT, ads.ProductName);
            operation.AddIntParam(DB_COL_ID_USER_PREFERENCES, ads.IdUserPreferences);
            operation.AddDecimalParam(DB_COL_PRICE, ads.Price);
            operation.AddVarcharParam(DB_COL_USER, ads.Email);

            return operation;
        }

        //Search by id
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADVERTISING_ID_PR" };

            var ads = (Advertising)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCT, ads.IdProduct);

            return operation;
        }

        //Search by name
        public SqlOperation GetRetriveByNameStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADVERTISING_NAME_PR" };

            var ads = (Advertising)entity;
            operation.AddVarcharParam(DB_COL_PRODUCT, ads.ProductName);

            return operation;
        }

        //Search by state
        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            return null;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ADVERTISING_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADVERTISING_PR" };

            var ads = (Advertising)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCT, ads.IdProduct);
            operation.AddVarcharParam(DB_COL_PRODUCT, ads.ProductName);
            operation.AddIntParam(DB_COL_ID_USER_PREFERENCES, ads.IdUserPreferences);
            operation.AddDecimalParam(DB_COL_PRICE, ads.Price);
            operation.AddVarcharParam(DB_COL_USER, ads.Email);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ADVERTISING_PR" };

            var ads = (Advertising)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCT, ads.IdProduct);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var product = BuildObject(row);
                lstResults.Add(product);
            }

            return lstResults;
        }
    }
}
