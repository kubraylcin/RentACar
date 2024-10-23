using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constans.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            if (customers == null || customers.Count == 0)
            {
                return new ErrorDataResult<List<Customer>>(CustomerMessages.NoCustomersFound);
            }

            return new SuccessDataResult<List<Customer>>(customers, CustomerMessages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var customer = _customerDal.Get(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(CustomerMessages.CustomerNotFound);
            }

            return new SuccessDataResult<Customer>(customer);
        }
        [SecuredOperation("Admin,CustomerSupport")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.CustomerUpdated);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessages.CustomerDeleted);
        }
    }
}
