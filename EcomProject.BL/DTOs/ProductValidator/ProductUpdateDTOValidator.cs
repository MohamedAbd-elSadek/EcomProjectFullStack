using EcomProject.BL.DTOs.Product;
using EcomProject.DAL.UOW;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.ProductValidator
{
    public class ProductUpdateDTOValidator :AbstractValidator<ProductUpdateDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductUpdateDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name Cannot Be Empty")

                .MinimumLength(3)
                .WithMessage("Name Must be more than 3 Chars")

                .MaximumLength(60)
                .WithMessage("Name Cannot Exceed 60 Chars");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description Cannot Be Empty")

                .MinimumLength(3)
                .WithMessage("Description Must be more than 3 Chars")

                .MaximumLength(150)
                .WithMessage("Description Cannot Exceed 150 Chars");

            RuleFor(x => x.ManufactureDate)
                .NotEmpty()
                .WithMessage("Manufacture Date Cannot Be Empty")

                .MustAsync(IsNotFromFutureAsync)
                .WithMessage("The Product Manufacture date must be a date from the past");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price Cannot be Empty")

                .InclusiveBetween(0, 100000)
                .WithMessage("The price is between 0 and 100000");

            RuleFor(x => x.Discount)
                .NotEmpty()
                .WithMessage("Discount Cannot be Empty")

                .InclusiveBetween(0, 100)
                .WithMessage("The Discount is between 0 and 100");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Discount Cannot be Empty")

                .MustAsync(ValidCategoryId)
                .WithMessage("This Category Id is not Valid");

        }

        private async Task<bool> ValidCategoryId(Guid guid, CancellationToken token)
        {
            var category = await _unitOfWork.CategoryRepo.GetAsync(guid);
            if (category == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> IsNotFromFutureAsync(DateOnly only, CancellationToken token)
        {
            var asyncfunc = await _unitOfWork.ProductRepo.GetAllAsync();
            var today = DateOnly.FromDateTime(DateTime.Now);
            return only <= today;
        }
    }
}
