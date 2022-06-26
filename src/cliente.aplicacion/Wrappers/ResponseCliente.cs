namespace cliente.aplicacion.Wrappers
{
    public class ResponseCliente <T>
    {
        public ResponseCliente()
        {

        }

        public ResponseCliente(string? mensaje = null)
        {
            Success = true;
            Message = mensaje;
        }

        public ResponseCliente(T valores, string? mensaje = null)
        {
            Success = true;
            Message = mensaje;
            Data = valores;
        }

        public bool Success { get;  set; }
        public string? Message { get;  set; }
        public T? Data { get;  set; }
        public List<string> Errors { get; set; }
    }
}
