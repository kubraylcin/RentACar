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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentals = _rentalDal.GetAll();
            if (rentals == null || rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(RentalMessages.NoRentalsFound);
            }

            return new SuccessDataResult<List<Rental>>(rentals, RentalMessages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalId);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(RentalMessages.RentalNotFound);
            }

            return new SuccessDataResult<Rental>(rental);
        }
        [SecuredOperation("Admin,Accounting")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessages.RentalUpdated);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(RentalMessages.RentalDeleted);
        }

    }
}
