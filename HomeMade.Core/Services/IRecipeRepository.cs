using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public interface IRecipeRepository
    {
        Recipe Add(Recipe recipe);

        Recipe Get(int id);

        Recipe Update(Recipe recipe);

        void Remove(Recipe recipe);

        IEnumerable<Recipe> GetAll(); // List? Collection? Benefits and Drawbacks?
    }
}
