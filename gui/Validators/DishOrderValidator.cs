using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using gui.ApiClient.Models;

namespace gui.Validators
{
    public class DishOrderValidator : AbstractValidator<DishOrder>
    {
        public DishOrderValidator()
        {
            RuleFor(d => d.DishIdentifier)
                .NotEmpty()
                .WithName("Identyfikator potrawy");
            
            RuleFor(d => d.Quantity)
                .GreaterThan(0)
                .WithName("Ilość");

        }

    }
}
