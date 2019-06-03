using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;


namespace DataAcess.Mapper
{
    public class StoreAdministratorMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NAME = "NAME_1";
        private const string DB_COL_LAST_NAME1 = "LAST_NAME_1";
        private const string DB_COL_LAST_NAME2 = "LAST_NAME_2";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_STORE = "ID_STORE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var storeAdmin = new StoreAdministrator
            {
                Name = GetStringValue(row, DB_COL_NAME),
                FirstLastName = GetStringValue(row, DB_COL_LAST_NAME1),
                SecondLastName = GetStringValue(row, DB_COL_LAST_NAME2),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Active = GetBooleanValue(row, DB_COL_ACTIVE)
            };

            return storeAdmin;
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
            var operation = new SqlOperation { ProcedureName = "CRE_STORE_ADMINISTRATOR_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_NAME, storeAdmin.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, storeAdmin.FirstLastName);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, storeAdmin.SecondLastName);
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, storeAdmin.Password);
            operation.AddVarcharParam(DB_COL_STORE, storeAdmin.Store);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_STORE_ADMINISTRATOR_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_STORE_ADMINISTRATOR_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_STORE_ADMINISTRATOR_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_NAME, storeAdmin.Name);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, storeAdmin.FirstLastName);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, storeAdmin.SecondLastName);
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);

            return operation;
        }

        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_STORE_ADMINISTRATOR_STATE_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);
            operation.AddBooleanParam(DB_COL_ACTIVE, storeAdmin.Active);

            return operation;
        }
    }
}
