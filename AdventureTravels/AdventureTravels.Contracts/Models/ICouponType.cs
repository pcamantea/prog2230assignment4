using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Contracts.Models
{
    public interface ICouponType
    {
        string CouponModule { get; set; }
        int CouponTypeId { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}
