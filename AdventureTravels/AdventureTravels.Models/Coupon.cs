using AdventureTravels.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Models
{
    public class Coupon : ICoupon
    {
        public int CouponId { get; set; }
        [MaxLength(10)]
        public string CouponCode { get; set; }
        public int CouponTypeId { get; set; }
        [MaxLength(150)]
        public string CouponDescription { get; set; }
        public int AppliesToProductId { get; set; }//to apply to specific product, based on ID
        public decimal Value { get; set; }
        public decimal MinSpend { get; set; }
        public bool MultipleUse { get; set; }
        [MaxLength(255)]
        public string AssignedTo { get; set; }
    }
}
