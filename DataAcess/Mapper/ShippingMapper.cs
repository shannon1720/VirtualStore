using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;


namespace DataAcess.Mapper
{
    public class ShippingMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_IDENTIFICATION = "IDENTIFICATION";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LOGO = "LOGO";
        private const string DB_COL_AREA_ENVIOS = "COVERED_AREA";
        private const string DB_COL_NUMERO_TELEFONO = "PHONE_NUMBER";
        private const string DB_COL_TIPOS_ENVIO = "ID";
        private const string DB_COL_TARIFA_BASE = "MINIMUM_RATE";
        private const string DB_COL_TARIFAXKILOMETRIO = "RATE";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_ID_CURRENCY = "ID_CURRENCY";
        private const string DB_COL_CURRENCY_NAME = "CURRENCY_NAME";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SHIPPING_PR" };

            var s = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICATION, s.Identification);
            operation.AddVarcharParam(DB_COL_NAME, s.Name);
            operation.AddVarcharParam(DB_COL_LOGO, s.Logo);
            operation.AddDecimalParam(DB_COL_AREA_ENVIOS, s.CoveredArea);
            operation.AddVarcharParam(DB_COL_NUMERO_TELEFONO, s.Phone_Number);
            operation.AddDecimalParam(DB_COL_TARIFA_BASE, s.Minimum_Rate);
            operation.AddDecimalParam(DB_COL_TARIFAXKILOMETRIO, s.Rate);
            operation.AddVarcharParam(DB_COL_EMAIL, s.Email);
            operation.AddIntParam(DB_COL_ID_CURRENCY, s.IdCurrency);

            return operation;
       }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SHIPPING_IdentificationPR"};

            var c = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICATION, c.Identification);

            return operation;
        }


        public SqlOperation GetRetriveEmailStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SHIPPING_PR" };

            var c = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SHIPPING_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SHIPPING_PR" };

            var s = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICATION, s.Identification);
            operation.AddVarcharParam(DB_COL_NAME, s.Name);
            operation.AddVarcharParam(DB_COL_LOGO, s.Logo);
            operation.AddDecimalParam(DB_COL_AREA_ENVIOS, s.CoveredArea);
            operation.AddVarcharParam(DB_COL_NUMERO_TELEFONO, s.Phone_Number);
            //operation.AddVarcharParam(DB_COL_TIPOS_ENVIO, s.TiposEnvio);
            operation.AddDecimalParam(DB_COL_TARIFA_BASE, s.Minimum_Rate);
            operation.AddDecimalParam(DB_COL_TARIFAXKILOMETRIO, s.Rate);
            operation.AddIntParam(DB_COL_ID_CURRENCY,s.IdCurrency);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_SHIPPING_PR" };

            var c = (Shipping)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICATION, c.Identification);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var shipping = new Shipping
            {
                Id = GetIntValue(row, DB_COL_ID),
                Identification = GetStringValue(row, DB_COL_IDENTIFICATION),
                Name = GetStringValue(row, DB_COL_NAME),
                Logo = GetStringValue(row, DB_COL_LOGO),
                CoveredArea = GetDecimalValue(row, DB_COL_AREA_ENVIOS),
                Phone_Number = GetStringValue(row, DB_COL_NUMERO_TELEFONO),
                // TiposEnvio=GetStringValue(row,DB_COL_TIPOS_ENVIO),
                Minimum_Rate = GetDecimalValue(row, DB_COL_TARIFA_BASE),
                Rate =GetDecimalValue(row,DB_COL_TARIFAXKILOMETRIO),
                Active=GetBooleanValue(row, DB_COL_ACTIVE),
                IdCurrency = GetIntValue(row, DB_COL_ID_CURRENCY),
                CurrencyName = GetStringValue(row, DB_COL_CURRENCY_NAME)
          
            };

            return shipping;
        }
    }
}
