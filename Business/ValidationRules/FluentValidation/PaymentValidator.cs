using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.PaymentId).GreaterThan(0).WithMessage("Ödeme ID'si sıfırdan büyük oolmalı.");
            RuleFor(p => p.RentalId).GreaterThan(0).WithMessage("Kiralama ID'si sıfırdan büyük olmalı.");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Miktar sıfırdan büyük olmalı.");
            RuleFor(p => p.PaymentDate).NotEmpty().WithMessage("Ödeme tarihi boş olamaz.");
            
        }
    }
}
