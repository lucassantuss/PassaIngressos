using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Ingresso", Schema = "venda")]
    public class Ingresso
    {
        [Key]
        [Column("Id_Ingresso")]
        public int Id { get; set; }

        [Column("Valor")]
        public decimal? Valor { get; set; }

        [Column("Id_Tipo_Ingresso")]
        public int IdTipoIngresso { get; set; }

        [Column("Id_Pessoa_Vendedora")]
        public int IdPessoaVendedora { get; set; }

        [Column("Id_Evento")]
        public int IdEvento { get; set; }
    }
}
