﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı E-posta adresi boş olamaz.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");
        }
    }
}
