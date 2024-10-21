using Business.Abstracts;
using Business.BusinessAspects.Autofac;
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
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        //[SecuredOperation("admin")]
        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult();
        }

        public IResult Delete(Service service)
        {
            _serviceDal.Delete(service);
            return new SuccessResult();
        }


        [SecuredOperation("admin")]
        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll());
        }

        public IDataResult<Service> GetById(int serviceId)
        {
            return new SuccessDataResult<Service>(_serviceDal.Get(s => s.ServiceId == serviceId));
        }

        public IResult Update(Service service)
        {
            _serviceDal.Update(service);
            return new SuccessResult();
        }
    }
}
