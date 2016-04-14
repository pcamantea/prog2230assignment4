using AdventureTravels.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTravels.Models
{
    public class CouponType : ICouponType
    {
        public int CouponTypeId { get; set; }
        public string CouponModule { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
