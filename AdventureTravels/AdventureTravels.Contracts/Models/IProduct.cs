using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Models
{
    public interface IProduct
    {
        decimal CostPrice { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
        string ProductDescription { get; set; }
        int ProductID { get; set; }
    }
}
