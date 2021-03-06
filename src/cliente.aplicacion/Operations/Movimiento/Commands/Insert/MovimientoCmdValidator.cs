using FluentValidation;

namespace cliente.aplicacion.Operations.Movimiento.Commands.Insert
{
    public class MovimientoCmdValidator : AbstractValidator<InsertMovimientoCmd>
    {

        protected enum TipoMovimiento
        {
            DEB,
            CRED,
            DEPO,
            RETI
        }

        public MovimientoCmdValidator()
        {
            RuleFor(val => val.IdCuenta)
                 .GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");

            RuleFor(val => val.TipoMovimiento)
                .NotNull().NotEmpty().WithMessage("El valor no puede estar vacio {PropertyName}")
                .IsEnumName(typeof(TipoMovimiento), true).WithMessage("El movimiento no es correcto {PropertyName}");

            RuleFor(val => val.ValorMovimiento)
                 .NotEqual(0).WithMessage("El valor ingresado no puede ser cero {PropertyName}");

            RuleFor(val => val.FechaMovimiento)
                .NotNull().NotEmpty().WithMessage("La fecha no puede estar vacia {PropertyName}")
                .LessThan(DateTime.Now.AddMinutes(5)).WithMessage("Las fechas estan defasadas con el servidor {PropertyName}")
                .GreaterThan(DateTime.Now.AddMinutes(-5)).WithMessage("Las fechas estan defasadas con el servidor {PropertyName}");
        }
    }
}
