using System.Data.SqlTypes;

namespace Usuarios.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string Email { get; set; }
        public int Type { get; set; } //1 - Diretor, 2 - Gerente, 3 - Colaborador
    }
}
