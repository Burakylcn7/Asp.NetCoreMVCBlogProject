using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu alan boş olamaz");
            
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.WriterMail).Matches(@"[@]+").WithMessage("Mail adresi @ içermelidir");
            RuleFor(x => x.WriterMail).Matches(@"[.]+").WithMessage("Mail adresi . içermelidir");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("Şifre uzunluğunuz en az 8 olmalıdır");
            RuleFor(x => x.WriterPassword).MaximumLength(16).WithMessage("Şifrenizin uzunluğu 16'yı geçmemelidir");
            RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermelidir");
            RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir");
            RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifreniz en az bir rakam içermelidir");
        }
    }
}
