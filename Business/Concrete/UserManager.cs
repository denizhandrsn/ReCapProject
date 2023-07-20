using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(Users user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {

            //iş kodları
            //koşul kodları
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Users>>(Messages.MaintananceTime);
            }

            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_userDal.Get(p=>p.Id == id),Messages.UserListed);
        }

        public IDataResult<Users> GetUserByEmail(string email)
        {
            return new SuccessDataResult<Users>(_userDal.Get(p => p.Email.Equals(email)),Messages.UsersListedByMail);
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails(),Messages.UserDetailsListed);
        }

        public IDataResult<List<Users>> GetUsersByName(string firstName)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p=>p.FirstName == firstName),Messages.UsersListedByName);
        }

        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
