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
    public class CarBusinessRules
    {
        ICarDal _carDal;
        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult CheckIfCarAlreadyExists(Car car)
        {
            var result = _carDal.GetAll().Contains(car);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfCarNameIsUsed(Car car)
        {
            var result = _carDal.Get(p => p.Description.Equals(car.Description));
            if (result!= null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
