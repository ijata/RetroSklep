using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class Storehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int storehouse_id { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public int delivery_id { get; set; }
        [Required]
        public float quantity { get; set; }
        [Required]
        public float price { get; set; }
        public char meansure_unit { get; set; }

        public Storehouse()
        {

        }
    }
}
