using AdventureTravels.Models;
using System.Data.Entity;

namespace AdventureTravels.Contracts.Data
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<BasketCoupon> BasketCoupons { get; set; }
        public DbSet<CouponType> CouponTypes { get; set; }

    }
}
