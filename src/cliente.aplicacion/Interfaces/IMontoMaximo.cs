namespace cliente.aplicacion.Interfaces
{
    public interface IMontoMaximo
    {
        DateTime FechaProceso { get; }
        DateTime FechaSiguiente { get; }
        decimal MontoMaximo { get; }
    }
}
