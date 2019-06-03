using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;


namespace DataAcess.Mapper
{
    public class BussinessManagerMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME_1 = "NAME_1";
        private const string DB_COL_NAME_2 = "NAME_2";
        private const string DB_COL_LAST_NAME_1 = "LAST_NAME_1";
        private const string DB_COL_LAST_NAME_2 = "LAST_NAME_2";
        private const string DB_COL_PHONE_1 = "PHONE_1";
        private const string DB_COL_PHONE_2 = "PHONE_2";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_URL_PROFILE_PRIC = "URL_PROFILE_PRIC";
        private const string DB_COL_URL_PHOTO_ID = "URL_PHOTO_ID";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_ADDRESS = "ID_ADDRESS";
        private const string DB_COL_SHIPPING = "ID_PROVIDER";
        private const string DB_COL_NAME_SHIPPING = "NAME";
        private const string DB_COL_STATE = "ACTIVE";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_BUSSINESS_MANAGER_PR" };

            var b = (BussinesManager)entity;
            operation.AddVarcharParam(DB_COL_ID, b.Id);
            operation.AddVarcharParam(DB_COL_NAME_1, b.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, b.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, b.LastName_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, b.LastName_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, b.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, b.Phone_2);
            operation.AddVarcharParam(DB_COL_EMAIL, b.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, b.Password);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, b.URL_Profile_Pric);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, b.URL_Photo_ID);
            
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_BUSSINESS_MANAGER_PR" };

            var b = (BussinesManager)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, b.Email);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_BUSSINESS_MANAGER_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_BUSSINESS_MANAGER_PR" };

            var b = (BussinesManager)entity;
            operation.AddVarcharParam(DB_COL_ID, b.Id);
            operation.AddVarcharParam(DB_COL_NAME_1, b.Name_1);
            operation.AddVarcharParam(DB_COL_NAME_2, b.Name_2);
            operation.AddVarcharParam(DB_COL_LAST_NAME_1, b.LastName_1);
            operation.AddVarcharParam(DB_COL_LAST_NAME_2, b.LastName_2);
            operation.AddVarcharParam(DB_COL_PHONE_1, b.Phone_1);
            operation.AddVarcharParam(DB_COL_PHONE_2, b.Phone_2);
            operation.AddVarcharParam(DB_COL_URL_PROFILE_PRIC, b.URL_Profile_Pric);
            operation.AddVarcharParam(DB_COL_URL_PHOTO_ID, b.URL_Photo_ID);
           
           
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var b = (BussinesManager)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, b.Email);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var bussines = BuildObject(row);
                lstResults.Add(bussines);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bussines = new BussinesManager
            {
                Id = GetStringValue(row, DB_COL_ID),
                Name_1 = GetStringValue(row, DB_COL_NAME_1),
                Name_2 = GetStringValue(row, DB_COL_NAME_2),
                LastName_1= GetStringValue(row, DB_COL_LAST_NAME_1),
                LastName_2 = GetStringValue(row, DB_COL_LAST_NAME_2),
                Phone_1 = GetStringValue(row, DB_COL_PHONE_1),
                Phone_2 = GetStringValue(row, DB_COL_PHONE_2),
                Email = GetStringValue(row, DB_COL_EMAIL),
                //Password = GetStringValue(row, DB_COL_PASSWORD),
                URL_Profile_Pric = GetStringValue(row, DB_COL_URL_PROFILE_PRIC),
                URL_Photo_ID = GetStringValue(row, DB_COL_URL_PHOTO_ID),
                //ID_Rol = GetIntValue(row, DB_COL_ID_ROL),
                Id_Address = GetIntValue(row, DB_COL_ADDRESS),
                Name=GetStringValue(row,DB_COL_NAME_SHIPPING),
                State= GetBooleanValue(row,DB_COL_STATE)
            };

            return bussines;
        }
    }
}
