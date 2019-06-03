using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class CategoryMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddIntParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetRetriveStatementName(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORY_NAME_PR" };

            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            return operation;
        } 

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORY_PR" };
            return operation;
        }

        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORY_STATE_PR" };

            var c = (Category)entity;
            operation.AddBooleanParam(DB_COL_ACTIVE, c.Active);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddIntParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            //operation.AddBooleanParam(DB_COL_ACTIVE, c.Active);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORY_PR" };

            var c = (Category)entity;
            operation.AddIntParam(DB_COL_ID, c.ID);
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
            var c = new Category
            {
                ID = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Active = GetBooleanValue(row, DB_COL_ACTIVE)
                //State = GetStringValue(row, Db)
            };
            return c;
        }
    }
}