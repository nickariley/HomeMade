using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; } //added

        public ICollection<RecipeModel> Recipes { get; set; }
    }
}
