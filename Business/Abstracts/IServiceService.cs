using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IServiceService
    {
        IDataResult<List<Service>> GetAll();
        IDataResult<Service> GetById(int serviceId);
        IResult Add(Service service);
        IResult Update(Service service);
        IResult Delete(Service service);
    }
}
