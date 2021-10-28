﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük ücret 0' dan büyük olmalıdır.");
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.ModelYear).NotEmpty();
            //Markası 1 olan arabanın günlük ücreti 50 den büyük olmalı.
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(50).When(c => c.BrandId == 1);
        }
    }
}
