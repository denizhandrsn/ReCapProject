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
    public class ColorBusinessRules
    {
        IColorDal _colorDal;
        public ColorBusinessRules(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        public IResult CheckIfColorAlreadyExists(Colors color)
        {
            var result = _colorDal.GetAll().Contains(color);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfColorNameIsUsed(Colors color)
        {
            var result = _colorDal.Get(p => p.ColorName.Equals(color.ColorName));
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
