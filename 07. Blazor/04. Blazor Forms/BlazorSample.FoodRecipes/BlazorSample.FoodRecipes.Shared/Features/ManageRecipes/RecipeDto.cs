using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;
public class RecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Originality { get; set; }
    public int TimeInMinuts { get; set; }
    public int Price { get; set; }
    public List<IngridientDto> Ingridients { get; set; } = new List<IngridientDto>();
}
public class IngridientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class RecipeDtoValidator:AbstractValidator<RecipeDto>
{
    public RecipeDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Please enter a name");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Please enter a description");
        RuleFor(c => c.Originality).NotEmpty().WithMessage("Please enter a originality");
        RuleFor(c => c.Price).GreaterThan(0).WithMessage("Please enter a value greater than 0");
        RuleFor(c => c.TimeInMinuts).GreaterThan(0).WithMessage("Please enter a value greater than 0");
        RuleFor(c => c.Ingridients).NotEmpty().WithMessage("Please enter a ingridients");
        RuleForEach(c => c.Ingridients).SetValidator(new IngridientDtoValidator());
    }
}

public class IngridientDtoValidator : AbstractValidator<IngridientDto>
{
    public IngridientDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Please enter a name");
    }
}