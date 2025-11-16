namespace SistemaReservaSalas.Clases
{
    public class Asistente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Si hay un combo/paquete seleccionado para este asistente
        // (ej: 1 = Básico, 2 = Intermedio, 3 = Premium)
        public int ComboSeleccionado { get; set; }

        // Precio por hora o por unidad; decimal para dinero.
        public decimal PrecioBase { get; set; }
        public object[] NombreAsistente { get; internal set; }

        public decimal ObtenerPrecioCombo()
        {
            switch (ComboSeleccionado)
            {
                case 1: return 10.00m;
                case 2: return 20.00m;
                case 3: return 25.00m;
                default:
                    // Si no hay combo definido, usar PrecioBase si está puesto, else 0
                    return PrecioBase > 0 ? PrecioBase : 0.00m;
            }
        }

        // Calcula costo en base a duración (en horas). Ajusta si tu duración está en otra unidad.
        public decimal CalcularCosto(decimal duracionHoras)
        {
            var precio = ObtenerPrecioCombo();
            return precio * duracionHoras;
        }
        public Asistente(string nombreAsistente, int comboSeleccionado)
        {
            Nombre = nombreAsistente;
            ComboSeleccionado = comboSeleccionado;
        }

    }
}
