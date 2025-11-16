namespace SistemaReservaSalas.Clases
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string NombreSala { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public string Distribucion { get; set; }
        public bool TieneProyector { get; set; }
        public bool TieneOasis { get; set; }
        public bool TieneCafetera { get; set; }
        public bool TienePizarra { get; set; }
        public bool TieneAireAcondicionado { get; set; }
        public string OtrosEquipos { get; set; }
        public bool Disponible { get; set; }
    }
}
