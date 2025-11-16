namespace SistemaReservaSalas.Clases
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; } // username column in DB
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
