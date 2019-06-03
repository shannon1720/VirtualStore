using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;


namespace DataAcess.Mapper
{
    public class StoreAdministratorMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME_1";
        private const string DB_COL_LAST_NAME1 = "LAST_NAME_1";
        private const string DB_COL_LAST_NAME2 = "LAST_NAME_2";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_STORE = "ID_STORE";
        private const string DB_COL_PHONE = "PHONE_1";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var storeAdmin = new StoreAdministrator
            {
                Id= GetStringValue(row, DB_COL_ID),
                Name_1 = GetStringValue(row, DB_COL_NAME),
                Last_Name1 = GetStringValue(row, DB_COL_LAST_NAME1),
                Last_Name2 = GetStringValue(row, DB_COL_LAST_NAME2),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Id_Store = GetStringValue(row,DB_COL_STORE),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),
                Phone_1 = GetStringValue(row, DB_COL_PHONE)
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
            operation.AddVarcharParam(DB_COL_NAME, storeAdmin.Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, storeAdmin.Last_Name1);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, storeAdmin.Last_Name2);
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, storeAdmin.Password);
            operation.AddVarcharParam(DB_COL_STORE, storeAdmin.Id_Store);
            operation.AddVarcharParam(DB_COL_PHONE, storeAdmin.Phone_1);
            operation.AddVarcharParam(DB_COL_ID, storeAdmin.Id);

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

        internal SqlOperation GetRetriveStatementByEmail(StoreAdministrator storeAdmin)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SELLER_STORE_EMAIL_PR" };
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_EMAIL_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_STORE_ADMINISTRATOR_PR" };

            var storeAdmin = (StoreAdministrator)entity;
            operation.AddVarcharParam(DB_COL_NAME, storeAdmin.Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, storeAdmin.Last_Name1);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, storeAdmin.Last_Name2);
            operation.AddVarcharParam(DB_COL_EMAIL, storeAdmin.Email);
            operation.AddVarcharParam(DB_COL_ID, storeAdmin.Id);
            operation.AddVarcharParam(DB_COL_PHONE, storeAdmin.Phone_1);

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
