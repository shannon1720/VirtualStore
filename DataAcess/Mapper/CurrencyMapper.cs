using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class CurrencyMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_ISO = "ISO";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var currency = BuildObject(row);
                lstResults.Add(currency);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var currency = new Currency
            {
                
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Iso = GetStringValue(row, DB_COL_ISO),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),

            };
            return currency;
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
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CURRENCY_PR" };
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
    }
}
