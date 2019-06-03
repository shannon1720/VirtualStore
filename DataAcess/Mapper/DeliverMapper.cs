using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class DeliverMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME_1";
        private const string DB_COL_LAST_NAME1 = "LAST_NAME_1";
        private const string DB_COL_LAST_NAME2 = "LAST_NAME_2";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_PHONE = "PHONE_1";
        private const string DB_COL_ID_BUSSINESS = "ID_BUSSINESS";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var deliver = new Deliver
            {
                ID = GetStringValue(row, DB_COL_ID),
                Name_1 = GetStringValue(row, DB_COL_NAME),
                Last_Name1 = GetStringValue(row, DB_COL_LAST_NAME1),
                Last_Name2 = GetStringValue(row, DB_COL_LAST_NAME2),
                Phone_1 = GetStringValue(row, DB_COL_PHONE),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Active = GetBooleanValue(row, DB_COL_ACTIVE)
            };

            return deliver;
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
            var operation = new SqlOperation { ProcedureName = "CRE_DELIVER_PR" };

            var deliver = (Deliver)entity;
            operation.AddVarcharParam(DB_COL_NAME, deliver.Name_1);
            operation.AddVarcharParam(DB_COL_ID, deliver.ID);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, deliver.Last_Name1);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, deliver.Last_Name2);
            operation.AddVarcharParam(DB_COL_PHONE, deliver.Phone_1);
            operation.AddVarcharParam(DB_COL_EMAIL, deliver.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, deliver.Password);
            operation.AddVarcharParam(DB_COL_ID_BUSSINESS, deliver.Id_Bussiness);

            return operation;
        }

        public SqlOperation GetRetriveStatementDeliverEmail(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DELIVER_PR" };

            var shipping = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, shipping.Email);

            return operation;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var del = (Deliver)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, del.Email);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DELIVER_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DELIVER_PR" };

            var deliver = (Deliver)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, deliver.Email);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DELIVER_PR" };

            var deliver = (Deliver)entity;
            operation.AddVarcharParam(DB_COL_NAME, deliver.Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME1, deliver.Last_Name1);
            operation.AddVarcharParam(DB_COL_LAST_NAME2, deliver.Last_Name2);
            operation.AddVarcharParam(DB_COL_PHONE, deliver.Phone_1);
            operation.AddVarcharParam(DB_COL_EMAIL, deliver.Email);

            return operation;
        }
    }
}
