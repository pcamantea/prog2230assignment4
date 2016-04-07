using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;
using System;

namespace AdventureTravels.Contracts.Repositories
{
    public class BasketRepository : RepositoryBase<Basket>
    {
        public BasketRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

}
