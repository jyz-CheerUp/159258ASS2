using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ass_2.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Display (Name="Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}