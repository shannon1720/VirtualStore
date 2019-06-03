using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
   public  class Recipe_CartManager:BaseManager
    {
        private CrudFactoryRecipe_Cart crudRecipe_Cart;
        public Recipe_CartManager() {

            crudRecipe_Cart = new CrudFactoryRecipe_Cart();
        }

        public void Create(Recipe_Cart recipe_Cart) {
            crudRecipe_Cart.Create(recipe_Cart);
        }

    }

}
