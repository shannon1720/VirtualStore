using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class LogInMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ID = "ID_ROL";
        private const string DB_COL_STATE = "ACTIVE";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var logIn = new LogIn
            {
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Rol = GetIntValue(row, DB_COL_ID),
                State = GetBooleanValue(row, DB_COL_STATE)
            };

            return logIn;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var logIn = BuildObject(row);
                lstResults.Add(logIn);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOG_IN_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStaments.GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }
    }
}
