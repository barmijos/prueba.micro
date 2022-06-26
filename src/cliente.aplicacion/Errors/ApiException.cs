using System.Globalization;

namespace cliente.aplicacion.Error
{
    public sealed class ApiException : Exception
    {
        public ApiException() : base()
        {

        }

        public ApiException(string mensaje) : base(mensaje)
        {

        }

        public ApiException(string mensaje, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, mensaje, args))
        {

        }
    }
}
