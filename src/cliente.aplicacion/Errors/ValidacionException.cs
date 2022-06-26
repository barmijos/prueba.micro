using FluentValidation.Results;

namespace cliente.aplicacion.Error
{
    public sealed class ValidacionException : Exception
    {
        public ValidacionException() : base("Existe un error en la entidad")
        {
            Errores = new List<string>();
        }

        public ValidacionException(IEnumerable<ValidationFailure> errores) : this()
        {
            foreach (var error in errores)
            {
                if (error != null)
                    Errores.Add(error.ErrorMessage);
            }
        }

        public List<string> Errores { get; }
    }
}
