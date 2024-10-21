using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISellerService
    {
        IDataResult<List<Seller>> GetAll();
        IDataResult<Seller> GetById(int sellerId);
        IResult Add(Seller seller);
        IResult Update(Seller seller);
        IResult Delete(Seller seller);
    }
}
