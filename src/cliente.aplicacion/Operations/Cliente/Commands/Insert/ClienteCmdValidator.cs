using FluentValidation;

namespace cliente.aplicacion.Operations.Cliente.Commands.Insert
{
    public class ClienteCmdValidator : AbstractValidator<InsertClienteCmd>
    {
        public ClienteCmdValidator()
        {
            const string ErrorMessage = "El valor ingresado no es correcto para {PropertyName}";
            RuleFor(val => val.IdPersona)
                .GreaterThan(0).WithMessage(ErrorMessage);

            RuleFor(val => val.Contrasena)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MaximumLength(50).WithMessage(ErrorMessage);
        }
    }
}
