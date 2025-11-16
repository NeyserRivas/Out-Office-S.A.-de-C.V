namespace SistemaReservaSalas.Clases
{
    public class Asistente
    {
        public int IdAsistente { get; set; }
        public int IdReserva { get; set; }
        public string NombreAsistente { get; set; }
        public int ComboSeleccionado { get; set; } // 1,2,3

        public Asistente() { }

        public Asistente(int idAsistente, int idReserva, string nombreAsistente, int comboSeleccionado)
        {
            this.IdAsistente = idAsistente;
            this.IdReserva = idReserva;
            this.NombreAsistente = nombreAsistente;
            this.ComboSeleccionado = comboSeleccionado;
        }
    }
}
