using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constans.Messages;
using Core.CrossCuttingConcerns.Validation;
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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            var cars = _carDal.GetAll();
            if (cars == null || cars.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(CarMessages.NoCarsFound);
            }

            return new SuccessDataResult<List<Car>>(cars, CarMessages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var car = _carDal.Get(c => c.CarId == carId);
            if (car == null)
            {
                return new ErrorDataResult<Car>(CarMessages.CarNotFound);
            }

            return new SuccessDataResult<Car>(car);
        }
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(),car);
            _carDal.Add(car);
            return new SuccessResult(CarMessages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.CarDeleted);
        }
    }
}