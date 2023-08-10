using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        ColorBusinessRules _colorBusinessRules;
        public ColorManager(IColorDal colorDal, ColorBusinessRules colorBusinessRules)
        {
            _colorDal = colorDal;
            _colorBusinessRules = colorBusinessRules;
        }
        public IResult Add(Colors color)
        {
            IResult result = BusinessRules.Run(_colorBusinessRules.CheckIfColorAlreadyExists(color)
                , _colorBusinessRules.CheckIfColorNameIsUsed(color));
            if (result != null) { return result; }
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Colors color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Colors>> GetAll()
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll().ToList(),Messages.ColorsListed);
        }

        public IDataResult<Colors> GetById(int id)
        {
            return new SuccessDataResult<Colors>(_colorDal.Get(c=>c.Id == id));
        }

        public IResult Update(Colors color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
