using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class DeliveryPostion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int deliveryposition_id { get; set; }
        [Required]
        public int delivery_id { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public float quantity { get; set; }
        [Required]
        public char meansure_unit { get; set; }
        [Required]
        public float price_netto { get; set; }
        public float value_netto { get; set; }
        [Required]
        public int tax_id { get; set; }
        public float price_brutto { get; set; }
        public float value_brutto { get; set; }

        public DeliveryPostion()
        {

        }

    }
}
