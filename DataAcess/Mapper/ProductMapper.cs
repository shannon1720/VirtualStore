using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class ProductMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_PRICE_INITIAL = "PRICE_INITIAL";
        private const string DB_COL_PRICE_FINAL = "PRICE_FINAL";
        private const string DB_COL_START_TAXES = "TAXES";
        private const string DB_COL_PROVIDER = "PROVIDER";
        private const string DB_COL_ID_CATEGORY = "ID_CATEGORY";
        private const string DB_COL_ID_CURRENCY = "ID_CURRENCY";
        private const string DB_COL_STATE = "STATE";
        private const string DB_COL_ID_MEDIA = "ID_MEDIA";
        private const string DB_COL_CATEGORY_NAME = "CATEGORY_NAME";
        private const string DB_COL_CURRENCY_NAME = "CURRENCY_NAME";
        private const string DB_COL_STOCK = "STOCK";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var product = new Product
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                PriceInitial = GetDecimalValue(row, DB_COL_PRICE_INITIAL),
                PriceFinal = GetDecimalValue(row, DB_COL_PRICE_FINAL),
                Taxes = GetDecimalValue(row, DB_COL_START_TAXES),
                Provider = GetStringValue(row, DB_COL_PROVIDER),
                IdCategory = GetIntValue(row, DB_COL_ID_CATEGORY),
                IdCurrency = GetIntValue(row, DB_COL_ID_CURRENCY),
                State = GetBooleanValue(row, DB_COL_STATE),
                IdMedia=GetIntValue(row, DB_COL_ID_MEDIA),
                CategoryName = GetStringValue(row, DB_COL_CATEGORY_NAME),
                CurrencyName = GetStringValue(row, DB_COL_CURRENCY_NAME),
                Stock = GetIntValue(row, DB_COL_STOCK)
            };

            return product;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PRODUCT_PR" };

            var Product = (Product)entity;
            operation.AddIntParam(DB_COL_ID, Product.Id);
            operation.AddVarcharParam(DB_COL_NAME, Product.Name);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, Product.Description);
            operation.AddDecimalParam(DB_COL_PRICE_INITIAL, Product.PriceInitial);
            operation.AddDecimalParam(DB_COL_PRICE_FINAL, Product.PriceFinal);
            operation.AddDecimalParam(DB_COL_START_TAXES, Product.Taxes);
            operation.AddVarcharParam(DB_COL_PROVIDER, Product.Provider);
            operation.AddIntParam(DB_COL_ID_CATEGORY, Product.IdCategory);
            operation.AddIntParam(DB_COL_ID_CURRENCY, Product.IdCurrency);
            operation.AddBooleanParam(DB_COL_STATE, Product.State);

            return operation;
        }

        //Search by id
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCT_ID_PR" };

            var product = (Product)entity;
            operation.AddIntParam(DB_COL_ID, product.Id);

            return operation;
        }

        //Search by name
        public SqlOperation GetRetriveByNameStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCT_NAME_PR" };

            var product = (Product)entity;
            operation.AddVarcharParam(DB_COL_NAME, product.Name);

            return operation;
        }

        //Search by state
        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCT_STATE_PR" };

            var product = (Product)entity;
            operation.AddBooleanParam(DB_COL_STATE, product.State);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCT_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRODUCT_PR" };

            var Product = (Product)entity;
            operation.AddIntParam(DB_COL_ID, Product.Id);
            operation.AddVarcharParam(DB_COL_NAME, Product.Name);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, Product.Description);
            operation.AddDecimalParam(DB_COL_PRICE_INITIAL, Product.PriceInitial);
            operation.AddDecimalParam(DB_COL_PRICE_FINAL, Product.PriceFinal);
            operation.AddDecimalParam(DB_COL_START_TAXES, Product.Taxes);
            operation.AddVarcharParam(DB_COL_PROVIDER, Product.Provider);
            operation.AddIntParam(DB_COL_ID_CATEGORY, Product.IdCategory);
            operation.AddIntParam(DB_COL_ID_CURRENCY, Product.IdCurrency);
            operation.AddBooleanParam(DB_COL_STATE, Product.State);
            operation.AddIntParam(DB_COL_STOCK, Product.Stock);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PRODUCT_PR" };

            var prouct = (Product)entity;
            operation.AddDecimalParam(DB_COL_ID, prouct.Id);
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
