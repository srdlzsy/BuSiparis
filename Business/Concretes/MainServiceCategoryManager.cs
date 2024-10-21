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
    public class MainServiceCategoryManager : IMainServiceCategoryService
    {
        IMainServiceCategoryDal _mainServiceCategoryDal;

        public MainServiceCategoryManager(IMainServiceCategoryDal mainServiceCategoryDal)
        {
            _mainServiceCategoryDal = mainServiceCategoryDal;
        }

        public IResult Add(MainServiceCategory mainServiceCategory)
        {
            _mainServiceCategoryDal.Add(mainServiceCategory);
            return new SuccessResult();
        }

        public IResult Delete(MainServiceCategory mainServiceCategory)
        {
            _mainServiceCategoryDal.Delete(mainServiceCategory);
            return new SuccessResult();
        }

        public IDataResult<List<MainServiceCategory>> GetAll()
        {
            return new SuccessDataResult<List<MainServiceCategory>>(_mainServiceCategoryDal.GetAll());
        }

        public IDataResult<MainServiceCategory> GetById(int mainServiceCategoryId)
        {
            return new SuccessDataResult<MainServiceCategory>(_mainServiceCategoryDal.Get(msc=>msc.MainServiceCategoryId==mainServiceCategoryId));
        }

        public IResult Update(MainServiceCategory mainServiceCategory)
        {
            _mainServiceCategoryDal.Update(mainServiceCategory);
            return new SuccessResult(); 
        }
    }
}
