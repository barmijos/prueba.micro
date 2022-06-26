using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cliente.aplicacion.Operations.Persona.Commands.Insert
{
    public class PersonaCmdValidator : AbstractValidator<InsertPersonCmd>
    {
        public PersonaCmdValidator()
        {
            const string ErrorMessage = "El valor ingresado no es correcto para {PropertyName}";
            RuleFor(val => val.Nombre)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MaximumLength(50).WithMessage(ErrorMessage);

            RuleFor(val => val.Identificacion)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MinimumLength(10).WithMessage(ErrorMessage)
                .MaximumLength(13).WithMessage(ErrorMessage);

            RuleFor(val => val.Genero)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage);

            RuleFor(val => val.Edad)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .GreaterThanOrEqualTo(18).WithMessage(ErrorMessage);


            RuleFor(val => val.Direccion)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MaximumLength(100).WithMessage(ErrorMessage);

            RuleFor(val => val.Telefono)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MaximumLength(12).WithMessage(ErrorMessage);
        }
    }
}
