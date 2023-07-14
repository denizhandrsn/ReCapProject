using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        List<Customer> _customerList;
        public InMemoryCustomerDal()
        {
            _customerList = new List<Customer> 
            {
            new Customer{CustomerFirsName="Denizhan",CustomerLastName="Dursun",CustomerId=1,NationalityNumber="12345678910"},
            new Customer{CustomerFirsName="Fulden",CustomerLastName="Özsayın",CustomerId=2,NationalityNumber="12345678911"},
            new Customer{CustomerFirsName="Mert",CustomerLastName="Tanrıverdioğlu",CustomerId=3,NationalityNumber="12345678912"},
            new Customer{CustomerFirsName="Sadık",CustomerLastName="Özatak",CustomerId=4,NationalityNumber="12345678913"},
            new Customer{CustomerFirsName="Taha",CustomerLastName="Yavuz",CustomerId=5,NationalityNumber="12345678914"}
            };
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public List<Customer> CustomerGetAll()
        {
            return _customerList;
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(Customer customer)
        {
            Customer customerToDelete =_customerList.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            _customerList.Remove(customerToDelete);
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer customerToUpdate =_customerList.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            customerToUpdate.CustomerFirsName = customer.CustomerFirsName;
            customerToUpdate.CustomerLastName = customer.CustomerLastName;
            customerToUpdate.CustomerId = customer.CustomerId;
            customerToUpdate.NationalityNumber = customer.NationalityNumber;

        }
    }
}
