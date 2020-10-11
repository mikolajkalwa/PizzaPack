using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using FluentValidation;

namespace api.Validators
{
    public class PlaceOrderValidator : AbstractValidator<PlaceOrder>
    {
        public PlaceOrderValidator()
        {
            RuleFor(placeOrder => placeOrder.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("{PropertyValue} is not a valid email address.");

            RuleFor(placeOrder => placeOrder.Dishes)
                .NotEmpty();

            RuleForEach(placeOrder => placeOrder.Dishes).SetValidator(new DishOrderValidator());
        }
    }

    public class DishOrderValidator : AbstractValidator<DishOrder>
    {
        public DishOrderValidator()
        {
            RuleFor(d => d.DishIdentifier)
                .NotEmpty();

            RuleFor(d => d.Quantity)
                .GreaterThan(0);
        }
    }
}
