using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentValidation;
using gui.ApiClient.Models;

namespace gui.Validators
{
    class PlaceOrderValidator : AbstractValidator<PlaceOrder>
    {
        public PlaceOrderValidator()
        {
            RuleFor(placeOrder => placeOrder.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                .WithName("Adres Email");

            RuleFor(placeOrder => placeOrder.Dishes)
                .NotEmpty()
                .WithName("Zamawiane dania");

            RuleForEach(PlaceOrder => PlaceOrder.Dishes).SetValidator(new DishOrderValidator());
        }
    }
}