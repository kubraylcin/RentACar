using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(rental => rental.Id).GreaterThan(0).WithMessage("Kiralama ID'si 0'dan büyük olmalıdır");

            RuleFor(rental => rental.CarId).GreaterThan(0).WithMessage("Araç ID'si 0'dan büyük olmalıdır");

            RuleFor(rental => rental.CustomerId).GreaterThan(0).WithMessage("Müşteri ID'si 0'dan büyük olmalıdır");

            RuleFor(rental => rental.RentDate).NotEmpty().WithMessage("Kiralama tarihi boş olamaz");

            RuleFor(rental => rental.ReturnDate).GreaterThan(rental => rental.RentDate)
                .When(rental => rental.ReturnDate.HasValue)
                .WithMessage("İade tarihi, kiralama tarihinden büyük olmalıdır");

            RuleFor(rental => rental.TotalAmount).GreaterThan(0).WithMessage("Toplam miktar sıfırdan büyük olmalıdır");

            
        }
    }
}
