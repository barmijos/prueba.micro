using FluentValidation;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Insert
{
    public class CuentaCmdValidator : AbstractValidator<InsertCuentaCmd>
    {
        private const int SaldoInicialPermitido = 50;

        public enum TipoCuenta
        {
            AHO,
            COR
        }

        public CuentaCmdValidator()
        {

            RuleFor(val => val.SaldoInicial).NotEmpty().WithMessage("El valor ingresado no es correcto para {PropertyName}")
                .GreaterThan(SaldoInicialPermitido).WithMessage("El saldo no permitodo {PropertyName}");

            RuleFor(val => val.TipoCuenta).NotNull().NotEmpty().WithMessage("La informacion ingresado no es correcto para {PropertyName}")
                .IsEnumName(typeof(TipoCuenta)).WithMessage("El tipo de cuenta no es correcto para {PropertyName}");

            RuleFor(val => val.NumeroCuenta).NotEmpty().WithMessage("La informacion ingresado no es correcto para {PropertyName}")
                .MinimumLength(8).MaximumLength(12).WithMessage("La informacion ingresado no es correcto para {PropertyName}");

        }
    }
}
