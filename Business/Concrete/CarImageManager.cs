using Business.Abstract;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImages carImages)
        {
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImages carImages)
        {
            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(p=>p.Id == id));
        }

        public IResult Update(CarImages carImages)
        {
            _carImageDal.Update(carImages);
            return new SuccessResult();
        }

        
    }
}
