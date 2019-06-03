using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;


namespace DataAcess.Mapper
{
    public class StoreMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LOGO = "URL_LOGO";
        private const string DB_COL_PHONE_NUMBER = "PHONE";
        private const string DB_COL_CATEGORY = "ID_CATEGORY";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_EARNINGS = "EARNINGS";
        private const string DB_COL_CELLAR = "ID_CELLAR";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var store = new Store
            {
                Id = GetStringValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Logo = GetStringValue(row, DB_COL_LOGO),
                PhoneNumber = GetStringValue(row, DB_COL_PHONE_NUMBER),
                Category = GetIntValue(row, DB_COL_CATEGORY),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),
                Earnings = GetDecimalValue(row, DB_COL_EARNINGS),
                Cellar = GetIntValue(row, DB_COL_CELLAR)
            };

            return store;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var deliver = BuildObject(row);
                lstResults.Add(deliver);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_STORE_PR" };

            var store = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, store.Id);
            operation.AddVarcharParam(DB_COL_NAME, store.Name);
            operation.AddVarcharParam(DB_COL_LOGO, store.Logo);
            operation.AddVarcharParam(DB_COL_PHONE_NUMBER, store.PhoneNumber);
            operation.AddIntParam(DB_COL_CATEGORY, store.Category);
            operation.AddDecimalParam(DB_COL_EARNINGS, store.Earnings);
            if (store.Cellar.HasValue)
                operation.AddIntParam(DB_COL_CELLAR, store.Cellar);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_STORE_PR" };

            var store = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, store.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_STORE_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_STORE_PR" };

            var store = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, store.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_STORE_PR" };

            var store = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, store.Id);
            operation.AddVarcharParam(DB_COL_NAME, store.Name);
            operation.AddVarcharParam(DB_COL_LOGO, store.Logo);
            operation.AddVarcharParam(DB_COL_PHONE_NUMBER, store.PhoneNumber);
            operation.AddIntParam(DB_COL_CATEGORY, store.Category);
            operation.AddBooleanParam(DB_COL_ACTIVE, store.Active);
            operation.AddDecimalParam(DB_COL_EARNINGS, store.Earnings);

            return operation;
        }

        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_STORE_STATE_PR" };

            var store = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, store.Id);
            operation.AddBooleanParam(DB_COL_ACTIVE, store.Active);

            return operation;
        }
    }
}
