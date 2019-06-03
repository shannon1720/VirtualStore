using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{

    public class ClientMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_ID = "ID";
        private const string DB_COL_URL_PHOTO_ID = "URL_PHOTO_ID";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_NAME_1 = "NAME_1";
        private const string DB_COL_NAME_2 = "NAME_2";
        private const string DB_COL_LAST_NAME_1 = "LAST_NAME_1";
        private const string DB_COL_LAST_NAME_2 = "LAST_NAME_2";
        private const string DB_COL_PHONE_1 = "PHONE_1";
        private const string DB_COL_PHONE_2 = "PHONE_2";
        private const string DB_COL_ID_ADDRESS = "ID_ADDRESS";
        private const string DB_COL_URL_PROFILE_PRIC = "URL_PROFILE_PRIC";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ACTIVE = "ACTIVE";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_CLIENT_PR" };

            var client = (Client)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, client.Email);
            operation.AddVarcharParam(DB_COL_ID, client.Id);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, client.Url_Photo_Id);
            operation.AddIntParam(DB_COL_ID_ROL, client.Id_Rol);
            operation.AddVarcharParam(DB_COL_NAME_1, client.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, client.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, client.Last_Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, client.Last_Name_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, client.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, client.Phone_2);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, client.Url_Profile_Pric);
            operation.AddVarcharParam(DB_COL_PASSWORD, client.Password);
            operation.AddBooleanParam(DB_COL_ACTIVE, client.Active);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CLIENT_PR" };
            return operation;
        }


        //GET BY STATE
        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENT_STATE_PR" };

            var client = (Client)entity;
            operation.AddBooleanParam(DB_COL_ACTIVE, client.Active);

            return operation;
        }

        //GET BY EMAIL
        public SqlOperation GetRetriveByEmailStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENT_EMAIL_PR" };

            var client = (Client)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, client.Email);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CLIENT_PR" };

            var client = (Client)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, client.Email);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, client.Url_Photo_Id);
            operation.AddVarcharParam(DB_COL_NAME_1, client.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, client.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, client.Last_Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, client.Last_Name_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, client.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, client.Phone_2);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, client.Url_Profile_Pric);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var client = (Client)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, client.Email);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var client = BuildObject(row);
                lstResults.Add(client);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var client = new Client
            {
                Email = GetStringValue(row, DB_COL_EMAIL),
                Id = GetStringValue(row, DB_COL_ID),
                Url_Photo_Id = GetStringValue(row, DB_COL_URL_PHOTO_ID),
                Id_Rol = GetIntValue(row, DB_COL_ID_ROL),
                Name_1 = GetStringValue(row, DB_COL_NAME_1),
                Name_2= GetStringValue(row, DB_COL_NAME_2),
                Last_Name_1 = GetStringValue(row, DB_COL_LAST_NAME_1),
                Last_Name_2 = GetStringValue(row, DB_COL_LAST_NAME_2),
                Password= GetStringValue(row, DB_COL_PASSWORD),
                Phone_1 = GetStringValue(row, DB_COL_PHONE_1),
                Phone_2= GetStringValue(row, DB_COL_PHONE_2),
                Id_Address= GetIntValue(row, DB_COL_ID_ADDRESS),
                Url_Profile_Pric = GetStringValue(row, DB_COL_URL_PROFILE_PRIC),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),
              
            };
            return client;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

