using FluentValidation;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Business.ValidationRules
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsImage).NotEmpty().WithMessage("Haber resmini boş geçemezsiniz");
            RuleFor(x => x.NewsImage).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz");
            RuleFor(x => x.NewsTitle).NotEmpty().WithMessage("Haber başlığını boş geçemezsiniz");
            RuleFor(x => x.NewsTitle).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz");
            RuleFor(x => x.NewsContent).NotEmpty().WithMessage("Haber içeriğini boş geçemezsiniz");
        }
    }
}
