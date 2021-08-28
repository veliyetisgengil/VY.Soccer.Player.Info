using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Models.Player;

namespace VY.Soccer.Player.Info.Api.Validation
{
    public class PlayerValidator : AbstractValidator<PlayerDTO>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100den büyük olamaz");
        }
    }
}
