using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class CellarMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_LATITUDE = "LATITUDE";
        private const string DB_COL_ID_LONGITUDE = "LONGITUDE";
        private const string DB_COL_ADDRESS = "DETAILED_ADDRESS";
        private const string DB_COL_ID_STORE = "ID_STORE";
        private const string DB_COL_STATE = "ACTIVE";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cellar = new Cellar
            {
                Id = GetIntValue(row, DB_COL_ID),
                Latitude = GetDecimalValue(row, DB_COL_ID_LATITUDE),
                Longitude = GetDecimalValue(row, DB_COL_ID_LONGITUDE),
                Address = GetStringValue(row, DB_COL_ADDRESS),
                Id_Store = GetStringValue(row, DB_COL_ID_STORE),
                State = GetStringValue(row, DB_COL_STATE)
            };

            return cellar;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cellar = BuildObject(row);
                lstResults.Add(cellar);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CELLAR_PR" };

            var cellar = (Cellar)entity;
            operation.AddDecimalParam(DB_COL_ID_LATITUDE, cellar.Latitude);
            operation.AddDecimalParam(DB_COL_ID_LONGITUDE, cellar.Longitude);
            operation.AddVarcharParam(DB_COL_ID_STORE, cellar.Id_Store);
            operation.AddVarcharParam(DB_COL_ADDRESS, cellar.Address);

            return operation;
        }

          public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CELLAR_PR" };
            return operation;

        }

         public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CELLAR_PR" };

            var cellar = (Cellar)entity;
            operation.AddVarcharParam(DB_COL_ID_STORE, cellar.Id_Store);

            return operation;
        }

       public SqlOperation  GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CELLAR_PR" };

            var cellar = (Cellar)entity;
            operation.AddIntParam(DB_COL_ID, cellar.Id);
            operation.AddDecimalParam(DB_COL_ID_LATITUDE, cellar.Latitude);
            operation.AddDecimalParam(DB_COL_ID_LONGITUDE, cellar.Longitude);
            operation.AddVarcharParam(DB_COL_ID_STORE, cellar.Id_Store);
            operation.AddVarcharParam(DB_COL_ADDRESS, cellar.Address);

            return operation;
        }
    }
    
}
