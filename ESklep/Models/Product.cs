using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public string? product_description { get; set; }
        [Required]
        public char meansure_unit { get; set; }
        public int? year { get; set; }
        public int? author_id { get; set; }

        public Product()
        {

        }
    }
}
