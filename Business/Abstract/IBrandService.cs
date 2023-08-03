using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brands>> GetAll();
        IDataResult<Brands> GetById(int id);
        IResult Add(Brands brand);
        IResult Update(Brands brand);
        IResult Delete(Brands brand);
    }
}
