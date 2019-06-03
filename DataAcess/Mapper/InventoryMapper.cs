using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class InventoryMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_STOCK = "STOCK";
        private const string DB_COL_ACTIVE = "ACTIVE";
        private const string DB_COL_ID_PRODUCT = "ID_PRODUCT";
        private const string DB_COL_ID_CELLAR = "ID_CELLAR";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var inventory = new Inventory
            {
                Id = GetIntValue(row, DB_COL_ID),
                Stock = GetIntValue(row, DB_COL_STOCK),
                IdProduct = GetIntValue(row, DB_COL_ID_PRODUCT),
                IdCellar = GetIntValue(row, DB_COL_ID_CELLAR),
                Active = GetBooleanValue(row, DB_COL_ACTIVE)
            };

            return inventory;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var inventory = BuildObject(row);
                lstResults.Add(inventory);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_INVENTORY_PR" };

            var deliver = (Inventory)entity;
            operation.AddIntParam(DB_COL_ID_CELLAR, deliver.IdCellar);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_INVENTORY_PR" };

            var del = (Inventory)entity;
            operation.AddIntParam(DB_COL_ID_CELLAR, del.Id);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_INVENTORY_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_INVENTORY_PR" };

            var inventory = (Inventory)entity;
            operation.AddIntParam(DB_COL_ID_CELLAR, inventory.Id);

            return operation;
        }

        public SqlOperation GetRetriveProductByCellarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCT_CELLAR_PR" };

            var inventory = (Inventory)entity;
            operation.AddIntParam(DB_COL_ID_CELLAR, inventory.IdCellar);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_INVENTORY_PR" };

            var inventory = (Inventory)entity;
            operation.AddIntParam(DB_COL_STOCK, inventory.Stock);
            operation.AddIntParam(DB_COL_ID, inventory.Id);
            operation.AddIntParam(DB_COL_ID_PRODUCT, inventory.IdProduct);
            operation.AddIntParam(DB_COL_ID_CELLAR, inventory.IdCellar);

            return operation;
        }

    }
}
