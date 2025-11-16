namespace SistemaReservaSalas.Clases
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // Propiedad que representa la columna 'Usuario' en la BD (username)
        // NO puede llamarse igual que la clase (no puede ser "Usuario")
        public string UsuarioNombre { get; set; }

        // Para compatibilidad si algún código usa 'NombreUsuario'
        public string NombreUsuario
        {
            get => UsuarioNombre;
            set => UsuarioNombre = value;
        }

        public string Password { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        public Usuario() { }

        // Constructor que muchos DAO esperan (Id, Nombre, Email, Telefono, UsuarioNombre, Password, Rol, Activo)
        public Usuario(int idUsuario, string nombre, string email, string telefono, string usuarioNombre, string password, string rol, bool activo)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            UsuarioNombre = usuarioNombre;
            Password = password;
            Rol = rol;
            Activo = activo;
        }
    }
}
