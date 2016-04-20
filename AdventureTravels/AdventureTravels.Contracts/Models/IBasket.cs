using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Models
{
    public interface IBasket
    {
        void AddBasketCoupon(IBasketCoupon coupon);
        System.Collections.Generic.ICollection<IBasketCoupon> IBasketCoupons { get; }
        Guid BasketID { get; set; }
        decimal BasketItemCount();
        System.Collections.Generic.ICollection<IBasketItem> IBasketItems { get; }
        decimal BasketTotal();
        DateTime OrderDate { get; set; }
    }
}
