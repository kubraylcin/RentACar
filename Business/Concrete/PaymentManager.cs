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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var payments = _paymentDal.GetAll();
            if (payments == null || payments.Count == 0)
            {
                return new ErrorDataResult<List<Payment>>(PaymentMessages.NoPaymentsFound);
            }

            return new SuccessDataResult<List<Payment>>(payments, PaymentMessages.PaymentsListed);
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            var payment = _paymentDal.Get(p => p.PaymentId == paymentId);
            if (payment == null)
            {
                return new ErrorDataResult<Payment>(PaymentMessages.PaymentNotFound);
            }

            return new SuccessDataResult<Payment>(payment);
        }
        [SecuredOperation("Admin,Accounting")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(PaymentMessages.PaymentAdded);
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(PaymentMessages.PaymentUpdated);
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(PaymentMessages.PaymentDeleted);
        }
    }
}
