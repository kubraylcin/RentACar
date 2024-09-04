using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Brand)
            .NotEmpty().WithMessage("Marka boş olamaz")
            .MaximumLength(50).WithMessage("Marka 50 karakterden uzun olamaz");

            RuleFor(c => c.Model)
            .NotEmpty().WithMessage("Model boş olamaz")
            .MaximumLength(50).WithMessage("Model 50 karakterden uzun olamaz");

            RuleFor(c => c.Year)
            .GreaterThan(1990).WithMessage("Yıl 1990'dan büyük olmalıdır")
           .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Yıl {DateTime.Now.Year} veya daha küçük olmalıdır");

            RuleFor(c => c.DailyRate)
            .GreaterThan(0).WithMessage("Günlük ücret sıfırdan büyük olmalıdır");

            RuleFor(c => c.IsAvailable)
            .NotNull().WithMessage("Uygunluk belirtilmelidir");

            RuleFor(c => c.DailyPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Günlük fiyat sıfır veya daha büyük olmalıdır");
        }

    }
}
