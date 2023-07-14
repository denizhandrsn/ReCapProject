using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal() 
        { 
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=12,DailyPrice=230,Description="Honda Civic",ModelYear= "2005"},
                new Car{CarId=2,BrandId=1,ColorId=11,DailyPrice=250,Description="Honda Nsx",ModelYear= "2000"},
                new Car{CarId=3,BrandId=1,ColorId=10,DailyPrice=210,Description="Honda Civic",ModelYear= "2002"},
                new Car{CarId=4,BrandId=1,ColorId=9,DailyPrice=290,Description="Honda Accent",ModelYear= "1999"},
                new Car{CarId=5,BrandId=1,ColorId=2,DailyPrice=280,Description="Honda Crv",ModelYear= "2018"}

            };
        
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int iD)
        {
            Car carToGet = _cars.SingleOrDefault(c => c.CarId == iD);
            return carToGet;

        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
