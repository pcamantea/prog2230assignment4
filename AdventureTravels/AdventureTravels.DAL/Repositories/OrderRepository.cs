using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;
using System;

namespace AdventureTravels.Contracts.Repositories
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(DataContext context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}
