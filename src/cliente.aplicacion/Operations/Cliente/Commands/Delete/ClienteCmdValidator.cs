using FluentValidation;

namespace cliente.aplicacion.Operations.Cliente.Commands.Delete
{
    public class ClienteCmdValidator : AbstractValidator<DeleteClienteCmd>
    {
        /// <summary>
        /// Validacion de tipos de datos para eliminar la informacion
        /// </summary>
        public ClienteCmdValidator()
        {
            RuleFor(val => val.IdCliente).NotEmpty().WithMessage("El valor ingresado no es correcto para {PropertyName}")
                .GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");
        }
    }
}
