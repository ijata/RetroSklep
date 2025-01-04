using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
        public string name { get; set; }
        public bool is_root { get; set; }
        public int root_lvl { get; set; }

        public Category()
        {

        }
    }
}
