using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CategoryManager : BaseManager
    {
        private CategoryCrudFactory crudCategory;

        public CategoryManager()
        {
            crudCategory = new CategoryCrudFactory();
        }

        public void Create(Category category)
        {
            try
            {
                var a = crudCategory.RetrieveByName2<Category>(category);

                if (a != null)
                {
                    //Category already exist
                    throw new BussinessException(3);
                }
                else
                    crudCategory.Create(category);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Category> RetrieveAll()
        {
           
            var c = crudCategory.RetrieveAll<Category>();

            foreach (var category in c)
            {

                if (category.Active)
                {

                    category.State = "Activado";
                }
                else { category.State = "Desactivado"; };

            }

            return c;
        }

        public Category RetrieveById(Category category)
        {
            Category c = null;
            try
            {
                c = crudCategory.Retrieve<Category>(category);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return c;
        }

        public Category RetrieveByName2(Category category)
        {
            Category c = null;
            try
            {
                c = crudCategory.RetrieveByName2<Category>(category);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return c;
        }


        //public Category RetrieveByName(Category category)
        //{
        //    Category c = null;
        //    try
        //    {
        //        c = crudCategory.RetrieveByName<Category>(category);
        //        if (c == null)
        //        {
        //            throw new BussinessException(4);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.GetInstance().Process(ex);
        //    }
        //    return c;
        //}

        public List<Category> RetrieveByState(Category category)
        {
            return crudCategory.RetrieveByState<Category>(category);
        }

        public void Update(Category category)
        {
            crudCategory.Update(category);
        }

        public void Delete(Category category)
        {
            crudCategory.Delete(category);
        }
    }
}