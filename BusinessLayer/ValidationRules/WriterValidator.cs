using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(c => c.Writername).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(c => c.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş beçilemez");
            RuleFor(c => c.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(c => c.Writername).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla girmeyiniz");
            RuleFor(c => c.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla girmeyiniz");
            RuleFor(c => c.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş geçilemez");
          //  RuleFor(c => c.WriterAbout).Must(Inside).WithMessage("Hakkında yazısının içinde mutlaka 'A' harfi bulunmalıdır");
        }
    /*    private bool Inside(string args)
        {
            return args.Contains("A");
        } */
     

    }
}
