using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rentals rental)
        {
            IResult result= BusinessRules.Run(CheckIfCarAlreadyRented(rental));

            if (result != null ) { return result; }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll());
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        private IResult CheckIfCarAlreadyRented(Rentals rental)
        {
            var result = _rentalDal.GetAll().Contains(rental);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
