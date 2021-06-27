using FluentValidation;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar resmini boş geçemezsiniz");
            RuleFor(x => x.WriterImage).MaximumLength(250).WithMessage("En fazla 250 karakter girebilirsiniz");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Yazar mail adresini boş geçemezsiniz");
            RuleFor(x => x.WriterEmail).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifresini boş geçemezsiniz");
            RuleFor(x => x.WriterPassword).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
        }
    }
}