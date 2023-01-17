using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentFinalAPI.Models
{
    public class PaymentDetailsModel
    {
        public int PaymentDetailId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; } // mm/yy
        public string SecurityCode { get; set; }
    }
}
