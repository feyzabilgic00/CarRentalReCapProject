using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description_).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);
        }
    }
}
