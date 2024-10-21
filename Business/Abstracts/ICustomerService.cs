using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();  
        IDataResult<Customer> GetById(int customerId);  
        IResult Add(Customer customer);  
        IResult Update(Customer customer);  
        IResult Delete(Customer customer);  
    }
}
