using FavoretoAppX.Domain.Models;
using FluentValidation;

namespace FavoretoAppX.Domain.Validations;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("O nome do produto é obrigatório.");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("A quantidade do produto deve ser maior ou igual a zero.");
    }
}