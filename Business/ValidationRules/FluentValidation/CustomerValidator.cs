using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerId)
           .GreaterThan(0).WithMessage("Müşteri ID'si 0'dan büyük olmalıdır");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz")
                .MaximumLength(50).WithMessage("Ad 50 karakterden uzun olamaz");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz")
                .MaximumLength(50).WithMessage("Soyad 50 karakterden uzun olamaz");


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girilmelidir");


            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası girilmelidir");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz")
                .MaximumLength(100).WithMessage("Adres 100 karakterden uzun olamaz");
        }
    }
}
