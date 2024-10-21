using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class MainServiceCategory :IEntity
    {
        public int MainServiceCategoryId { get; set; }    
        public string MainServiceCategoryName { get; set; } 
        public int ProfitModelId { get; set; }         
    }

}
