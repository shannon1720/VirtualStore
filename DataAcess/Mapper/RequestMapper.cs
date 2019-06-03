using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class RequestMapper: EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_USER = "ID_USER";
        private const string DB_COL_ID_MEDIA = "ID_MEDIA";
        private const string DB_COL_ID_CATEGORY = "ID_CATEGORY";
        private const string DB_COL_ELAPSED_TIME = "ELAPSED_TIME";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_ACTIVE= "ACTIVE";
        private const string DB_COL_CATEGORY_NAME = "CATEGORY_NAME";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var request = new Request
            {
                Id = GetIntValue(row, DB_COL_ID),
                IdUser = GetStringValue(row, DB_COL_ID_USER),
                IdMedia = GetIntValue(row, DB_COL_ID_MEDIA),
                IdCategory= GetIntValue(row, DB_COL_ID_CATEGORY),
                CategoryName=GetStringValue(row, DB_COL_CATEGORY_NAME),
                ElapsedTime = GetDateValue(row, DB_COL_ELAPSED_TIME),
                Description= GetStringValue(row, DB_COL_DESCRIPTION),
                Active= GetBooleanValue(row, DB_COL_ACTIVE)
            };

            return request;       
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var request = BuildObject(row);
                lstResults.Add(request);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USER_REQUEST_PR" };

            var request = (Request)entity;

            operation.AddVarcharParam(DB_COL_ID_USER, request.IdUser);       
            operation.AddIntParam(DB_COL_ID_CATEGORY, request.IdCategory);
            operation.AddDateTimeParam(DB_COL_ELAPSED_TIME, request.ElapsedTime);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, request.Description);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_REQUEST_PR" };

            var request = (Request)entity;
            operation.AddIntParam(DB_COL_ID, request.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER_REQUEST_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_REQUEST_ID_PR" };

            var request = (Request)entity;
            operation.AddIntParam(DB_COL_ID, request.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveByEmailStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_REQUEST_EMAIL_PR" };

            var request = (Request)entity;
            operation.AddVarcharParam(DB_COL_ID_USER, request.IdUser);

            return operation;
        }

    }
}
