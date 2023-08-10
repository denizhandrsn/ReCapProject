using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        UserBusinessRules _userBusinessRules;
        public UserManager(IUserDal userDal, UserBusinessRules userBusinessRules)
        {
            _userDal = userDal;
            _userBusinessRules = userBusinessRules;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            
            IResult result = BusinessRules.Run(_userBusinessRules.CheckIfUserAlreadyExists(user)
                ,_userBusinessRules.CheckIfEmailIsUsed(user));
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            //iş kodları
            //koşul kodları
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintananceTime);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User > GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.Id == id),Messages.UserListed);
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Email.Equals(email)),Messages.UsersListedByMail);
        }

        public IDataResult<List<UserDetailsDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails(),Messages.UserDetailsListed);
        }

        public IDataResult<List<User>> GetUsersByName(string firstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p=>p.FirstName == firstName),Messages.UsersListedByName);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
