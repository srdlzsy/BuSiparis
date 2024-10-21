using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ServiceCategoryManager : IServiceCategoryService
    {
        IServiceCategoryDal _serviceCategoryDal;
        public ServiceCategoryManager(IServiceCategoryDal serviceCategoryDal)
        {
            _serviceCategoryDal = serviceCategoryDal;
        }
        public IResult Add(ServiceCategory serviceCategory)
        {
            _serviceCategoryDal.Add(serviceCategory);
            return new SuccessResult();
        }

        public IResult Delete(ServiceCategory serviceCategory)
        {
            _serviceCategoryDal.Delete(serviceCategory);
            return new SuccessResult();
        }

        public IDataResult<List<ServiceCategory>> GetAll()
        {
            return new SuccessDataResult<List<ServiceCategory>>(_serviceCategoryDal.GetAll());
        }

        public IDataResult<ServiceCategory> GetById(int serviceCategoryId)
        {
            return new SuccessDataResult<ServiceCategory>(_serviceCategoryDal.Get(sc => sc.ServiceCategoryId == serviceCategoryId));
        }

        public IResult Update(ServiceCategory serviceCategory)
        {
            _serviceCategoryDal.Update(serviceCategory);
            return new SuccessResult();
        }
    }
}
