using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public interface IIngredientRepository
    {
        Ingredient Add(Ingredient ingredient);

        Ingredient Get(int id);

        Ingredient Update(Ingredient ingredient);

        void Remove(Ingredient ingredient);

        IEnumerable<Ingredient> GetAll(); // List? Collection? Benefits and Drawbacks?
    }
}
