using FluentValidation;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanını boş geçemezsiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanını boş geçemezsiniz");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresini boş geçemezsiniz");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreyi boş geçemezsiniz");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
        }
    }
}