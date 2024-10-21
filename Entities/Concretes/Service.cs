using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Service : IEntity
    {
        public int ServiceId { get; set; } 
        public int SellerId { get; set; } 
        public int ServiceCategoryId { get; set; } 
        public string Description { get; set; } 
        public decimal Amount { get; set; } 
    }

}
