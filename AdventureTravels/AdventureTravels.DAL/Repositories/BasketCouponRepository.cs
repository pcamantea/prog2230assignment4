﻿using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Repositories
{
    public class BasketCouponRepository : RepositoryBase<BasketCoupon>
    {
        public BasketCouponRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
