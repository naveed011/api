using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymendDetail.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public String SecurityCode { get; set; }
    }
}