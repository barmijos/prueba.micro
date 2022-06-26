using FluentValidation;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Delete
{
    public class CuentaCmdValidator : AbstractValidator<DeleteCuentaPorIdCmd>
    {
        public CuentaCmdValidator()
        {
            RuleFor(val => val.IdCuenta).NotEmpty().WithMessage("El valor ingresado no es correcto para {PropertyName}")
                .GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");
        }
    }
}
