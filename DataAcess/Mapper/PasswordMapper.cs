using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class PasswordMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";

        public SqlOperation UpdPassword(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PASSWORD_USER_PR" };

            var user = (Password)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, user.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.UserPassword);

            return operation;
        }

        //GET BY EMAIL
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_EMAIL_PR" };

            var s = (Password)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new Password
            {
                Email = GetStringValue(row, DB_COL_EMAIL),
                UserPassword = GetStringValue(row, DB_COL_PASSWORD),
            };
            return user;
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
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
