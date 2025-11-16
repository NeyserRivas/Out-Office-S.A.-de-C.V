namespace SistemaReservaSalas.Clases
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // Cambié el nombre para evitar conflicto con el tipo
        public string UsuarioNombre { get; set; } // antes: public string Usuario { get; set; }

        public string Password { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
