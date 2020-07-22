using System;
using System.Collections.Generic;
using System.Text;


namespace HomeMade.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; } //added

        public ICollection<Recipe> Recipes { get; set; }
    }
}
