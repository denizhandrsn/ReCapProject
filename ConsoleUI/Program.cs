using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            
        }



        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}",car.BrandName,car.Description,car.ModelYear,car.ColorName,car.DailyPrice,car.CarId);
            }
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", car.Description, car.ModelYear, car.CarId, car.DailyPrice);
            //}
        }
    }
}