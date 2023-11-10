using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ass_2.Models
{
    public class Dish
    {
        [Key]
        [Display(Name="Dish Name")]
        public string Name { get; set; }
       
        public string steps { get; set; }
        public string material { get; set; }
        public string Image { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int Dishes { get; internal set; }
    }
}