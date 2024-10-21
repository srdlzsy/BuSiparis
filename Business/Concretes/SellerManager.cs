using Business.Abstracts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SellerManager : ISellerService
    {
        ISellerDal _sellerDal;
        public SellerManager(ISellerDal sellerDal)
        {
            _sellerDal = sellerDal;
        }

        public IResult Add(Seller seller)
        {
            _sellerDal.Add(seller);
            return new SuccessResult();
        }

        public IResult Delete(Seller seller)
        {
            _sellerDal.Delete(seller);
            return new SuccessResult();
        }

        public IDataResult<List<Seller>> GetAll()
        {
            return new SuccessDataResult<List<Seller>>(_sellerDal.GetAll());
        }

        public IDataResult<Seller> GetById(int sellerId)
        {
            return new SuccessDataResult<Seller>(_sellerDal.Get(s=>s.SellerId==sellerId));
        }

        public IResult Update(Seller seller)
        {
            _sellerDal.Update(seller);
            return new SuccessResult();
        }
    }
}
