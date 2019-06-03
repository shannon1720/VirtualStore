using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class PreferenceMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_PREFERENCE_1 = "PREFERENCE_1";
        private const string DB_COL_PREFERENCE_2 = "PREFERENCE_2";
        private const string DB_COL_PREFERENCE_3 = "PREFERENCE_3";
        private const string DB_COL_ACTIVE = "ACTIVE";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var preference = new Preference
            {
                Id = GetIntValue(row, DB_COL_ID),
                Preference1=GetIntValue(row, DB_COL_PREFERENCE_1),
                Preference2 = GetIntValue(row, DB_COL_PREFERENCE_2),
                Preference3 = GetIntValue(row, DB_COL_PREFERENCE_3)
            };
            return preference;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var preference = BuildObject(row);
                lstResults.Add(preference);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PREFERENCE_PR" };

            var preference = (Preference)entity;
            operation.AddIntParam(DB_COL_ID, preference.Id);
            operation.AddIntParam(DB_COL_PREFERENCE_1, preference.Preference1);
            operation.AddIntParam(DB_COL_PREFERENCE_2, preference.Preference2);
            operation.AddIntParam(DB_COL_PREFERENCE_3, preference.Preference3);
            operation.AddBooleanParam(DB_COL_ACTIVE, preference.Active);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PREFERENCE_PR" };

            var preference = (Preference)entity;
            operation.AddIntParam(DB_COL_ID, preference.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            {
                var operation = new SqlOperation { ProcedureName = "RET_PREFERENCE_PR" };

                var preference = (Preference)entity;
                operation.AddIntParam(DB_COL_ID, preference.Id);

                return operation;
            }
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PREFERENCE_PR" };

            var preference = (Preference)entity;
            operation.AddIntParam(DB_COL_ID, preference.Id);
            operation.AddIntParam(DB_COL_PREFERENCE_1, preference.Preference1);
            operation.AddIntParam(DB_COL_PREFERENCE_2, preference.Preference2);
            operation.AddIntParam(DB_COL_PREFERENCE_3, preference.Preference3);
            operation.AddBooleanParam(DB_COL_ACTIVE, preference.Active);

            return operation;
        }
    }

}
