using FluentValidation;

namespace cliente.aplicacion.Operations.Cliente.Commands.Update
{
    public class ClienteCmdValidator : AbstractValidator<UpdateClienteCmd>
    {
        public ClienteCmdValidator() 
        {

            const string ErrorMessage = "El valor ingresado no es correcto para {PropertyName}";
            RuleFor(val => val.IdCliente)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .GreaterThan(0).WithMessage(ErrorMessage);

            RuleFor(val => val.Contrasena)
                .NotEmpty().WithMessage(ErrorMessage)
                .NotNull().WithMessage(ErrorMessage)
                .MaximumLength(256).WithMessage(ErrorMessage);

            
        }
    }
}
