using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Tabela_Geral", Schema = "core")]
    public class TabelaGeral
    {
        [Key]
        [Column("Id_Tabela_Geral")]
        public int IdTabelaGeral { get; set; }

        [Column("Tabela")]
        public string Tabela { get; set; }
    }
}