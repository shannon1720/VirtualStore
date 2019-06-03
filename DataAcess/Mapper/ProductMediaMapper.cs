using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    class ProductMediaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_IMAGE_1 = "IMAGE_1";
        private const string DB_COL_IMAGE_2 = "IMAGE_2";
        private const string DB_COL_IMAGE_3 = "IMAGE_3";
        private const string DB_COL_IMAGE_4 = "IMAGE_4";
        private const string DB_COL_IMAGE_5 = "IMAGE_5";
        private const string DB_COL_VIDEO = "VIDEO";
        private const string DB_COL_ACTIVE = "ACTIVE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var productMedia = new ProductMedia
            {
                Id = GetIntValue(row, DB_COL_ID),
                Image1 = GetStringValue(row, DB_COL_IMAGE_1),
                Image2 = GetStringValue(row, DB_COL_IMAGE_2),
                Image3 = GetStringValue(row, DB_COL_IMAGE_3),
                Image4 = GetStringValue(row, DB_COL_IMAGE_4),
                Image5 = GetStringValue(row, DB_COL_IMAGE_5),
                Video = GetStringValue(row, DB_COL_VIDEO),
                Active= GetBooleanValue(row, DB_COL_ACTIVE)
            };
            return productMedia;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PRODUCT_MEDIA_PR" };

            var productMedia = (ProductMedia)entity;
            operation.AddIntParam(DB_COL_ID, productMedia.Id);
            operation.AddVarcharParam(DB_COL_IMAGE_1, productMedia.Image1);
            operation.AddVarcharParam(DB_COL_IMAGE_2, productMedia.Image2);
            operation.AddVarcharParam(DB_COL_IMAGE_3, productMedia.Image3);
            operation.AddVarcharParam(DB_COL_IMAGE_4, productMedia.Image4);
            operation.AddVarcharParam(DB_COL_IMAGE_5, productMedia.Image5);
            operation.AddVarcharParam(DB_COL_VIDEO, productMedia.Video);
            operation.AddBooleanParam(DB_COL_ACTIVE, productMedia.Active);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCT_MEDIA_PR" };

            var productMedia = (ProductMedia)entity;
            operation.AddIntParam(DB_COL_ID, productMedia.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRODUCT_MEDIA_PR" };

            var productMedia = (ProductMedia)entity;
            operation.AddIntParam(DB_COL_ID, productMedia.Id);
            operation.AddVarcharParam(DB_COL_IMAGE_1, productMedia.Image1);
            operation.AddVarcharParam(DB_COL_IMAGE_2, productMedia.Image2);
            operation.AddVarcharParam(DB_COL_IMAGE_3, productMedia.Image3);
            operation.AddVarcharParam(DB_COL_IMAGE_4, productMedia.Image4);
            operation.AddVarcharParam(DB_COL_IMAGE_5, productMedia.Image5);
            operation.AddVarcharParam(DB_COL_VIDEO, productMedia.Video);

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

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCT__PR" };
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
