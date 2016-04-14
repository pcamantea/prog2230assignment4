using AdventureTravels.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Models
{
    public class BasketCoupon : IBasketCoupon
    {
        public int BasketCouponID { get; set; }
        public int CouponId { get; set; }
        public Guid BasketID { get; set; }

        [MaxLength(10)]
        public string CouponCode { get; set; }
        [MaxLength(100)]
        public string CouponType { get; set; }
        public decimal Value { get; set; }
        [MaxLength(150)]
        public string CouponDescription { get; set; }
        public int AppliesToProductId { get; set; }
    }
}
