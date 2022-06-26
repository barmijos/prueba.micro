using cliente.aplicacion.Interfaces;

namespace cliente.comun.Services
{
    public class CupoMaximoRetiro : IMontoMaximo
    {
        public decimal MontoMaximo => 1000;

        private  DateTime? fechaProceso;
        public DateTime FechaProceso
        {
            get
            {
                if (!fechaProceso.HasValue)
                        fechaProceso = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                return fechaProceso.Value;
            }
            
        }

        private DateTime? fechaSiguiente;
        public DateTime FechaSiguiente
        {
            get
            {
                if (!fechaSiguiente.HasValue)
                    fechaSiguiente = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());

                return fechaSiguiente.Value;
            }

        }
    }
}
