using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            //IResult result = BusinessRules.Run(
            //    CheckIfCarImagesCarLimit(carImage.CarId)
            //    );

            //if (result != null)
            //{
            //    return result;
            //}

            carImages.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImages.ImagePath);
            _carImageDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(p => p.Id == id));
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            //IResult result = BusinessRules.Run(
            //    CheckIfCarImagesCarLimit(carImage.CarId)
            //    );

            //if (result != null)
            //{
            //    return result;
            //}

            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }
        private IResult CheckIfCarImagesCarLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CheckIfCarImagesCarLimit);
            }
            return new SuccessResult();
        }

    }
}
