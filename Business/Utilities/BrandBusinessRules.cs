using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class BrandBusinessRules
    {
        IBrandDal _brandDal;
        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IResult CheckIfBrandAlreadyExists(Brands brand)
        {
            var result = _brandDal.GetAll().Contains(brand);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfBrandNameIsUsed(Brands brand)
        {
            var result = _brandDal.Get(p => p.BrandName.Equals(brand.BrandName));
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
