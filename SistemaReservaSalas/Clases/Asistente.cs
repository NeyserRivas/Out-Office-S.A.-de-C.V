using System;

namespace SistemaReservaSalas.Clases
{
    public class Asistente
    {
        // Propiedades compatibles con el código existente / DAO
        public int IdAsistente { get; set; }    // antes: IdAsistente
        public int IdReserva { get; set; }      // muchas partes del código acceden a IdReserva
        public string NombreAsistente { get; set; } // nombre usado en versiones anteriores
        public int ComboSeleccionado { get; set; }  // 1,2,3

        // Alias/compatibilidad adicional (opcional, facilita uso en código nuevo)
        public int Id
        {
            get => IdAsistente;
            set => IdAsistente = value;
        }

        public string Nombre
        {
            get => NombreAsistente;
            set => NombreAsistente = value;
        }

        // Precio base por hora (opcional, usado si no hay combo)
        public decimal PrecioBase { get; set; }

        // Constructor por defecto
        public Asistente() { }

        // Constructor que usan algunos formularios: nombre y combo
        public Asistente(string nombreAsistente, int comboSeleccionado)
        {
            NombreAsistente = nombreAsistente;
            ComboSeleccionado = comboSeleccionado;
        }

        // Esto se modificó: Constructor con 4 argumentos (solicitado por los DAOs en tus errores)
        // Firma típica: Asistente(int idAsistente, int idReserva, string nombreAsistente, int comboSeleccionado)
        public Asistente(int idAsistente, int idReserva, string nombreAsistente, int comboSeleccionado)
        {
            IdAsistente = idAsistente;
            IdReserva = idReserva;
            NombreAsistente = nombreAsistente;
            ComboSeleccionado = comboSeleccionado;
        }

        // Esto se modificó: ObtenerPrecioCombo() y CalcularCosto()
        public decimal ObtenerPrecioCombo()
        {
            switch (ComboSeleccionado)
            {
                case 1: return 10.00m;
                case 2: return 20.00m;
                case 3: return 25.00m;
                default: return PrecioBase > 0 ? PrecioBase : 0.00m;
            }
        }

        // Calcula el costo para este asistente según la duración (en horas)
        public decimal CalcularCosto(decimal duracionHoras)
        {
            return ObtenerPrecioCombo() * duracionHoras;
        }
    }
}

