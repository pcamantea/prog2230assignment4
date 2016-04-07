using AdventureTravels.Contracts.Data;

using AdventureTravels.Models;
using System;
using System.Linq;

namespace AdventureTravels.Contracts.Repositories
{
    public class CustomerRepository:RepositoryBase<Customer>
    {
        public CustomerRepository(DataContext context):base(context)
        {
            if (context==null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
