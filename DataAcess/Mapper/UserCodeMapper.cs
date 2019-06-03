using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class UserCodeMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_CODE = "CODE";

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var s = (UserCode)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            return operation;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
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
            var code = new UserCode
            {
                Email = GetStringValue(row, DB_COL_EMAIL),
                Code= GetStringValue(row, DB_COL_CODE)
            };
            return code;
        }
    }
}
