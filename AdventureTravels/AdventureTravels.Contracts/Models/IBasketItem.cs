using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Models
{
    public interface IBasketItem
    {
        Guid BasketID { get; set; }
        int BasketItemID { get; set; }
        IProduct IProduct { get; set; }
        int ProductID { get; set; }
        int Quantity { get; set; }
    }
}
