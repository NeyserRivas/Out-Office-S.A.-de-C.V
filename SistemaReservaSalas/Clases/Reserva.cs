using System;
using System.Collections.Generic;

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
    }
}
