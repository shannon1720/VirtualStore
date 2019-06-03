using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class AddressMapper : EntityMapper, ISqlStaments, IObjectMapper
    {



        private const string DB_COL_ID = "ID";
        private const string DB_COL_PROVINCE = "PROVINCE";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_CITY = "CITY";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";







        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bussines = new Address
            {
                Id = GetIntValue(row, DB_COL_ID),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                City = GetStringValue(row, DB_COL_CITY),
                Description= GetStringValue(row, DB_COL_DESCRIPTION)
               
            };

            return bussines;
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

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ADRESS_PR" };

            var a = (Address)entity;
           
            operation.AddVarcharParam(DB_COL_PROVINCE, a.Province);
            operation.AddVarcharParam(DB_COL_CANTON, a.Canton);
            operation.AddVarcharParam(DB_COL_CITY, a.City);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, a.Description);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADDRESS" };
            return operation;
        }


        public SqlOperation GetRetriveIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADDRESS_PR" };
            var a = (Address)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADRESS_PR" };

            var a = (Address)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_PROVINCE, a.Province);
            operation.AddVarcharParam(DB_COL_CANTON, a.Canton);
            operation.AddVarcharParam(DB_COL_CITY, a.City);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, a.Description);
            return operation;
        }
    }
}
