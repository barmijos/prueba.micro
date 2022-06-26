using FluentValidation;

namespace cliente.aplicacion.Operations.Movimiento.Commands.Delete
{
    public class MovimientoCmdValidator : AbstractValidator<DeleteMovimientoCmd>
    {
        public MovimientoCmdValidator()
        {
            RuleFor(val => val.IdMovimiento)
                .GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");

            RuleFor(val => val.IdCuenta)
                .GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");
        }
    }
}
