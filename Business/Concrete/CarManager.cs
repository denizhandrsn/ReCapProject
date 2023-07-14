using Business.Abstract;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            var carNameTest = carDal.Get(c => c.Description.Length < 2);
            if (carNameTest != null ) { Console.WriteLine(carNameTest.Description+" Araba ismi uzunluğu 2 harfen büyük olmalı"); }
            var carPriceTest = carDal.Get(c => c.DailyPrice < 1);
            if (carPriceTest != null ) { Console.WriteLine(carPriceTest.DailyPrice+" Araç kiralama fiyatı 0 olamaz"); }
            
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=> p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p=> p.ColorId == id);
        }
    }
}
