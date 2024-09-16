using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Arquivo", Schema = "core")]
    public class Arquivo
    {
        [Key]
        [Column("Id_Arquivo")]
        public int IdArquivo { get; set; }

        [Column("Conteudo_Arquivo")]
        public decimal ConteudoArquivo { get; set; }

        [Column("Extensao")]
        public string Extensao { get; set; }

        [Column("Content_Type")]
        public string ContentType { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
    }
}