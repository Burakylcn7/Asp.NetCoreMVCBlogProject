using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Lütfen 3 karakterden daha fazla veri girişi yapınız");
        }
    }
}
