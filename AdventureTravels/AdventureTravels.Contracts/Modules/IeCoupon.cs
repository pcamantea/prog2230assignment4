using AdventureTravels.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Modules
{
    public interface IeCoupon
    {
        void ProcessVoucher(ICoupon coupon, IBasket basket, IBasketCoupon basketCoupon);
    }
}
