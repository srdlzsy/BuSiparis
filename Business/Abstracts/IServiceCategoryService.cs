using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IServiceCategoryService
    {
        IDataResult<List<ServiceCategory>> GetAll();
        IDataResult<ServiceCategory> GetById(int serviceCategoryId);
        IResult Add(ServiceCategory serviceCategory);
        IResult Update(ServiceCategory serviceCategory);
        IResult Delete(ServiceCategory serviceCategory);
    }
}
