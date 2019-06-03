using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class RecipeMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        
        private const string DB_COL_ID = "ID";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_LONGITUDE = "LONGITUDE";
        private const string DB_COL_LATITUDE = "LATITUDE";
        private const string DB_COL_ID_PROVIDER = "ID_PROVIDER";
        private const string DB_COL_TOTAL_PROVIDER = "TOTAL_PROVIDER ";
        private const string DB_COL_TOTAL = "TOTAL";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Recipe = new Recipe
            {
                Id = GetIntValue(row, DB_COL_ID)
            };

            return Recipe;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var recipe = BuildObject(row);
                lstResults.Add(recipe);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_RECIPE_PR" };

            var c = (Recipe)entity;
           operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
           operation.AddDecimalParam(DB_COL_LONGITUDE, c.Longitud);
           operation.AddDecimalParam(DB_COL_LATITUDE, c.Latitud);
           operation.AddIntParam(DB_COL_ID_PROVIDER, c.IdProvider);
           operation.AddDecimalParam(DB_COL_TOTAL_PROVIDER, c.TotalProvider);
            operation.AddDecimalParam(DB_COL_TOTAL, c.Total);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        internal SqlOperation GetRetriveStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_MAX_RECIPE_PR" };
            return operation;
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
    }
}
