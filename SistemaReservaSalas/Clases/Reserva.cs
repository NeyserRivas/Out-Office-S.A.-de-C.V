using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemaReservaSalas.Clases
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdSala { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public decimal Duracion { get; set; }
        public string NombreResponsable { get; set; }
        public string EmailResponsable { get; set; }
        public string TelefonoResponsable { get; set; }
        public string PropositoEvento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        //// Propiedades devueltas por JOIN con Sala
        public string NombreSala { get; set; }
        public string UbicacionSala { get; set; }

        public List<Asistente> Asistentes { get; set; } = new List<Asistente>();

        public void CalcularHoraFin()
        {
            // Convertir Duracion (decimal horas) a TimeSpan
            // TimeSpan.FromHours requiere double, hacemos el cast seguro
            HoraFin = HoraInicio + TimeSpan.FromHours((double)Duracion);
        }
        public void CalcularTotales()
        {
            decimal subtotal = 0.00m;

            if (Asistentes != null && Asistentes.Any())
            {
                foreach (var a in Asistentes)
                {
                    try
                    {
                        subtotal += a.CalcularCosto(Duracion);
                    }
                    catch
                    {
                        // Si algún asistente no implementa CalcularCosto correctamente,
                        // evitamos que todo falle; puedes capturar/loguear si deseas.
                    }
                }
            }

            Subtotal = subtotal;

            // IVA: 12% 
            decimal porcentajeIva = 0.12m;
            IVA = Math.Round(Subtotal * porcentajeIva, 2, MidpointRounding.AwayFromZero);

            Total = Subtotal + IVA;
        }
    }
}
