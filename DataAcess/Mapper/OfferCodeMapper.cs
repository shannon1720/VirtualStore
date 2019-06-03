using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Dao;

namespace DataAcess.Mapper
{
    public class OfferCodeMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_CODE = "CODE";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_VALUE = "VALUE";
        private const string DB_COL_ID_PRODUCT = "ID_PRODUCT";
        private const string DB_COL_ID_PROVIDER = "ID_PROVIDER";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var offerCode = new OfferCode
            {
                Id = GetIntValue(row, DB_COL_ID),
                Code = GetStringValue(row, DB_COL_CODE),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                Value = GetDecimalValue(row, DB_COL_VALUE),
                Product = GetIntValue(row, DB_COL_CODE),
                Provider = GetIntValue(row, DB_COL_ID_PROVIDER),
                Active = GetBooleanValue(row, DB_COL_ACTIVE),
            };

            return offerCode;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_OFFER_CODE_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddVarcharParam(DB_COL_CODE, offerCode.Code);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, offerCode.Description);
            operation.AddDecimalParam(DB_COL_VALUE, offerCode.Value);
            operation.AddIntParam(DB_COL_CODE, offerCode.Product);
            operation.AddIntParam(DB_COL_ID_PROVIDER, offerCode.Provider);

            return operation;
        }

        //Search by id
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_OFFER_CODE_ID_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddIntParam(DB_COL_ID, offerCode.Id);

            return operation;
        }

        //Search by name
        public SqlOperation GetRetriveByNameStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_OFFER_CODE_NAME_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddVarcharParam(DB_COL_CODE, offerCode.Code);

            return operation;
        }

        //Search by state
        public SqlOperation GetRetriveByStateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_OFFER_CODE_STATE_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddBooleanParam(DB_COL_ACTIVE, offerCode.Active);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_OFFER_CODE_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_OFFER_CODE_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddIntParam(DB_COL_ID, offerCode.Id);
            operation.AddVarcharParam(DB_COL_CODE, offerCode.Code);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, offerCode.Description);
            operation.AddDecimalParam(DB_COL_VALUE, offerCode.Value);
            operation.AddIntParam(DB_COL_CODE, offerCode.Product);
            operation.AddIntParam(DB_COL_ID_PROVIDER, offerCode.Provider);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_OFFER_CODE_PR" };

            var offerCode = (OfferCode)entity;
            operation.AddIntParam(DB_COL_ID, offerCode.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var product = BuildObject(row);
                lstResults.Add(product);
            }

            return lstResults;
        }
    }
}
