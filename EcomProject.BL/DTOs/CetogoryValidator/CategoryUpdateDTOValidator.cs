using EcomProject.BL.DTOs.Category;
using EcomProject.DAL.UOW;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.CetogoryValidator
{
    public class CategoryUpdateDTOValidator :AbstractValidator<CategoryUpdateDTO>
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryUpdateDTOValidator(IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            RuleFor(c => c.Name).
                 NotEmpty()
                 .WithMessage("Name Cannot Be Empty")
                 .MaximumLength(30)
                 .WithMessage("Name Cannot Exceed 100 Characters")
                 .MinimumLength(3)
                 .WithMessage("Name Must be more than 3 Chars")
                 .MustAsync(NameIsUnique);

            RuleFor(c => c.Description).
                NotEmpty()
                .WithMessage("Description Cannot be Empty")

                .MaximumLength(300)
                .WithMessage("Name Cannot Exceed 100 Characters")
                .MinimumLength(3)
                .WithMessage("Name Must be more than 3 Chars");


        }

        private async Task<bool> NameIsUnique(string arg1, CancellationToken token)
        {
            var category = await unitOfWork.CategoryRepo.GetAllAsync();

            return !category.Any(c => c.Name == arg1);
        }
    }
}
