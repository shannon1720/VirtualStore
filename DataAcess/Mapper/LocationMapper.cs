using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class LocationMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LATITUDE = "LATITUDE";
        private const string DB_COL_LONGITUDE = "LONGITUDE";
        private const string DB_COL_STATE = "ACTIVE";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var location = new Location
            {
                Id = GetIntValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Latitude = GetFloatValue(row, DB_COL_LATITUDE),
                Longitude = GetFloatValue(row, DB_COL_LONGITUDE),
                State = GetBooleanValue(row, DB_COL_STATE)
            };

            return location;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var location = BuildObject(row);
                lstResults.Add(location);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_LOCATION_PR" };

            var c = (Location)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddFloatParam(DB_COL_LATITUDE, c.Latitude);
            operation.AddFloatParam(DB_COL_LONGITUDE, c.Longitude);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOCATION_PR" };

            var location = (Location)entity;
            operation.AddIntParam(DB_COL_ID, location.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LOCATION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LOCATION_PR" };

            var location = (Location)entity;
            operation.AddIntParam(DB_COL_ID, location.Id);
            operation.AddVarcharParam(DB_COL_NAME, location.Name);
            operation.AddFloatParam(DB_COL_LATITUDE, location.Latitude);
            operation.AddFloatParam(DB_COL_LONGITUDE, location.Longitude);
            return operation;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
