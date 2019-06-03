using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class SellerStoreMapper : EntityMapper, ISqlStaments, IObjectMapper
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
        private const string DB_COL_ID_STORE = "ID_STORE";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_SELLER_STORE_PR" };

            var s = (SellerStore)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            operation.AddVarcharParam(DB_COL_ID, s.ID);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, s.Url_Photo_ID);
            operation.AddVarcharParam(DB_COL_NAME_1, s.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, s.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, s.Last_Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, s.Last_Name_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, s.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, s.Phone_2);
            operation.AddIntParam(DB_COL_ID_ADDRESS, s.ID_Address);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, s.Url_Profile_Pric);
            operation.AddVarcharParam(DB_COL_PASSWORD, s.Password);
            operation.AddVarcharParam(DB_COL_ID_STORE, s.ID_Store);
            //operation.AddBooleanParam(DB_COL_ACTIVE, s.ACTIVE);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SELLER_STORE_PR" };
            return operation;
        }

        //GET BY EMAIL
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SELLER_STORE_EMAIL_PR" };

            var s = (SellerStore)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            return operation;
        }

        //GET BY STATE
        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SELLER_STORE_STATE_PR" };

            var s = (SellerStore)entity;
            //operation.AddBooleanParam(DB_COL_ACTIVE, s.ACTIVE);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SELLER_PR" };

            var s = (SellerStore)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, s.Url_Photo_ID);
            operation.AddVarcharParam(DB_COL_NAME_1, s.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, s.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, s.Last_Name_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, s.Last_Name_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, s.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, s.Phone_2);
            //operation.AddIntParam(DB_COL_ID_ADDRESS, s.ID_Address);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, s.Url_Profile_Pric);
            //operation.AddVarcharParam(DB_COL_ID_STORE, s.ID_STORE);
            //operation.AddBoolParam(DB_COL_ACTIVE, s.ACTIVE);

            return operation;
        }

        public SqlOperation UpdPassword(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PASSWORD_USER_PR" };

            var s = (SellerStore)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, s.Password);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var s = (SellerStore)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
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
            var seller = new SellerStore
            {
                Email = GetStringValue(row, DB_COL_EMAIL),
                ID = GetStringValue(row, DB_COL_ID),
                Url_Photo_ID= GetStringValue(row, DB_COL_URL_PHOTO_ID),
                ID_Rol = GetIntValue(row, DB_COL_ID_ROL),
                Name_1 = GetStringValue(row, DB_COL_NAME_1),
                Name_2 = GetStringValue(row, DB_COL_NAME_2),
                Last_Name_1 = GetStringValue(row, DB_COL_LAST_NAME_1),
                Last_Name_2 = GetStringValue(row, DB_COL_LAST_NAME_2),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Phone_1 = GetStringValue(row, DB_COL_PHONE_1),
                Phone_2 = GetStringValue(row, DB_COL_PHONE_2),
                ID_Address= GetIntValue(row, DB_COL_ID_ADDRESS),
                Url_Profile_Pric= GetStringValue(row, DB_COL_URL_PROFILE_PRIC),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),
               ID_Store = GetStringValue(row, DB_COL_ID_STORE),
            };
            return seller;
        }
    }
}
