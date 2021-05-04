using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapınız");
            RuleFor(c => c.CategoryName).MaximumLength(25).WithMessage("Lütfen 25 karakterden fazla değer girmeyiniz");
        }
    }
}
