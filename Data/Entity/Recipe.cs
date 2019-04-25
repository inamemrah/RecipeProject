using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
