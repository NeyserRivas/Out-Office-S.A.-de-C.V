using System;

namespace SistemaReservaSalas.Clases
{
    public class Usuario
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string text;
        private string v5;

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // Propiedad que representa la columna 'Usuario' en la BD (username)
        // NO puede llamarse igual que la clase (no puede ser "Usuario")
        public string UsuarioNombre { get; set; }

        // método EsAdministrador() para que los forms puedan preguntar el rol
        public bool EsAdministrador()
        {
            if (string.IsNullOrWhiteSpace(Rol))
                return false;
            return string.Equals(Rol.Trim(), "Administrador", StringComparison.OrdinalIgnoreCase);
        }

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

        public Usuario(string v1, string v2, string v3, string v4, string text, string v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.text = text;
            this.v5 = v5;
        }
    }
}
