﻿using System;
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
        public Basket()
        {
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

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
