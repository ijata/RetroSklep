using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class DeliveryHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int delivery_id { get; set; }
        [Required]
        public int storehouse_id { get; set; }
        public int number { get; set; }
        public int year { get; set; }
        public DateOnly delivery_date { get; set; }
        public TimeOnly delivery_time { get; set; }
        public float value_netto { get; set; }
        public float value_brutto { get; set; }
        public int status { get; set; }

        public DeliveryHeader()
        {

        }
    }
}
