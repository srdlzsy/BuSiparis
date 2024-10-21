using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Seller : IEntity
    {
        public int SellerId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateJoined { get; set; }
        public decimal Credit { get; set; }
    }
}
