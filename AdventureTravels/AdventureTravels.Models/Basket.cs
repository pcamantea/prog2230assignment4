using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Models
{
    public class Basket
    {
        public Guid BasketID { get; set; }
        public DateTime OrderDate { get; set; }
        private List<BasketCoupon> _basketCoupons;

        public virtual ICollection<BasketCoupon> BasketCoupons { get { return _basketCoupons; } set { _basketCoupons = value.ToList(); } }

        public Basket()
        {
            this.BasketCoupons = new List<BasketCoupon>();
            this.BasketItems = new List<BasketItem>();
        }

        public decimal BasketTotal()
        {
            decimal? total = (from item in BasketItems
                              select (int?)item.Quantity * item.Product.Price).Sum();
            return total ?? decimal.Zero;
        }

        public decimal BasketItemCount()
        {
            return BasketItems.Count();
        }

        public void AddBasketCoupon(BasketCoupon coupon)
        {
            _basketCoupons.Add((BasketCoupon)coupon);
        }    

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
