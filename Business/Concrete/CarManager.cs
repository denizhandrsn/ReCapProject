using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Business.Utilities;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        CarBusinessRules _carBusinessRules;

        public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules)
        {
            _carDal = carDal;
            _carBusinessRules = carBusinessRules;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(_carBusinessRules.CheckIfCarAlreadyExists(car)
                ,_carBusinessRules.CheckIfCarNameIsUsed(car));
            if (result != null) { return result; }
            _carDal.Add(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(_carBusinessRules.CheckIfCarAlreadyExists(car));
            if (result != null) { return result; }
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>>GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<CarDetailsDto>>GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
    }
}
