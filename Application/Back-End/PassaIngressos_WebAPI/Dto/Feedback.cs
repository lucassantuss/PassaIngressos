using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Feedback", Schema = "core")]
    public class Feedback
    {
        [Key]
        [Column("Id_Feedback")]
        public int IdFeedback { get; set; }

        [Column("Descricao_Feedback")]
        public string DescricaoFeedback { get; set; }

        [Column("Id_Pessoa")]
        public int? IdPessoa { get; set; }

        //[Column("Id_Pessoa")]
        //public Pessoa Pessoa { get; set; }
    }
}