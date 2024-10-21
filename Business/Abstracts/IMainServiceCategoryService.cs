using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IMainServiceCategoryService 
    {
        IDataResult<List<MainServiceCategory>> GetAll();
        IDataResult<MainServiceCategory> GetById(int mainServiceCategoryId);
        IResult Add(MainServiceCategory mainServiceCategory);
        IResult Update(MainServiceCategory mainServiceCategory);
        IResult Delete(MainServiceCategory mainServiceCategory);
    }
}
