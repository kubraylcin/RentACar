using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage("Şifre hash değeri boş olamaz.");

            RuleFor(user => user.PasswordSalt)
                .NotEmpty().WithMessage("Şifre salt değeri boş olamaz.");

            RuleFor(user => user.Status)
                .NotNull().WithMessage("Kullanıcı durumu boş olamaz.");
        }
    }
}
