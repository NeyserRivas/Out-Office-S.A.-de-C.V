using System.Collections.Generic;

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

        public string ObtenerEquipamiento()
        {
            var list = new List<string>();

            if (TieneProyector) list.Add("Proyector");
            if (TieneOasis) list.Add("Oasis");
            if (TieneCafetera) list.Add("Cafetera");
            if (TienePizarra) list.Add("Pizarra");
            if (TieneAireAcondicionado) list.Add("Aire acondicionado");

            if (!string.IsNullOrWhiteSpace(OtrosEquipos))
                list.Add(OtrosEquipos.Trim());

            if (list.Count == 0)
                return "Sin equipamiento adicional.";
            return string.Join(", ", list);
        }
    }
}
