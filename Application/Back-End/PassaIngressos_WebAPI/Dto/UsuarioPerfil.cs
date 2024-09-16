using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Usuario_Perfil", Schema = "acesso")]
    public class UsuarioPerfil
    {
        [Key]
        [Column("Id_Usuario_Perfil")]
        public int IdUsuarioPerfil { get; set; }

        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }

        //[Column("Id_Usuario")]
        //public Usuario Usuario { get; set; }

        [Column("Id_Perfil")]
        public int IdPerfil { get; set; }

        //[Column("Id_Perfil")]
        //public Perfil Perfil { get; set; }
    }
}