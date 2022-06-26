using FluentValidation;

namespace cliente.aplicacion.Operations.Persona.Commands.Delete
{
    public class PersonaCmdValidator : AbstractValidator<DeletePersonaCmd>
    {
        /// <summary>
        /// Validacion de tipos de datos para eliminar la informacion
        /// </summary>
        public PersonaCmdValidator()
        {
            RuleFor(val => val.IdPersona).GreaterThan(0).WithMessage("El valor ingresado no es correcto para {PropertyName}");
        }
    }
}
