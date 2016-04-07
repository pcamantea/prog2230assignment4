using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;
using System;

namespace AdventureTravels.Contracts.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem>
    {
        public BasketItemRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

}
