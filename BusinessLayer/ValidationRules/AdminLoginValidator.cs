using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminLoginValidator: AbstractValidator<Admin>
    {
        public AdminLoginValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.AdminUserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalı.");
            RuleFor(x => x.AdminPassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı.");
        }
    }
}
