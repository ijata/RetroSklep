using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class OrderPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderposition_id { get; set; }
        [Required]
        public int order_id { get; set; }
        [Required]
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int storehouse_id { get; set; } = 0;
        [Required]
        public float quantity { get; set; }
        public char meansure_unit { get; set; }
        public float price_netto { get; set; }
        public float value_netto { get; set; }
        public int tax_id { get; set; }
        public float price_brutto { get; set; }
        public float value_brutto { get; set; }
        public OrderPosition()
        {

        }
    }
}
