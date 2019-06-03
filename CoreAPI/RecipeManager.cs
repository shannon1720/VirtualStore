using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class RecipeManager:BaseManager
    {
        private CrudFactoryRecipe crudRecipe;


        public RecipeManager() {
            crudRecipe = new CrudFactoryRecipe();
        }
        public void Create(Recipe recipe)
        {
            crudRecipe.Create(recipe);
        }
        public Recipe Retrieve()
        {
            return crudRecipe.Retrieve<Recipe>();
        }

    }
}
