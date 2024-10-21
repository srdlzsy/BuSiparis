using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ServiceCategory : IEntity
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public  int  MainServiceCategoryId { get; set; }
        public string  Description { get; set; }


    }
}
