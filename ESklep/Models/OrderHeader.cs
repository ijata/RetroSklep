using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ESklep.Models
{
    public class OrderHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public int year { get; set; }
        public DateOnly order_date { get; set; }
        public TimeOnly order_time { get; set; }
        public int status { get; set; }
        [Required]
        public int client_id { get; set; }
        public float value_netto { get; set; }
        public float value_brutto { get; set; }
        public int realization_user_id { get; set; }
        public DateOnly realization_date { get; set; }
        public TimeOnly realization_time { get; set; }

        public OrderHeader()
        {

        }
    }
}
