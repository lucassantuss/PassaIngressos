using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Usuario", Schema = "acesso")]
    public class Usuario
    {
        [Key]
        [Column("Id_Usuario")]
        public int Id { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("Id_Pessoa")]
        public int IdPessoa { get; set; }
    }
}