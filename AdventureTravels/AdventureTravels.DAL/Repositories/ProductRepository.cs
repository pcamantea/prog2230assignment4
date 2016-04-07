using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;
using System;

namespace AdventureTravels.Contracts.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DataContext context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}

