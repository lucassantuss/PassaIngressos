using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Ingresso", Schema = "venda")]
    public class Ingresso
    {
        [Key]
        [Column("Id_Ingresso")]
        public int IdIngresso { get; set; }

        [Column("Id_Tipo_Ingresso")]
        public int IdTipoIngresso { get; set; }

        //[Column("Id_Tipo_Ingresso")]
        //public ItemTabelaGeral TipoIngresso { get; set; }

        [Column("Valor")]
        public decimal? Valor { get; set; }

        [Column("Id_Pessoa_Anunciante")]
        public int IdPessoaAnunciante { get; set; }

        //[Column("Id_Pessoa_Anunciante")]
        //public Pessoa PessoaAnunciante { get; set; }

        [Column("Id_Pessoa_Comprador")]
        public int IdPessoaComprador { get; set; }

        //[Column("Id_Pessoa_Comprador")]
        //public Pessoa PessoaComprador { get; set; }

        [Column("Id_Evento")]
        public int IdEvento { get; set; }

        //[Column("Id_Evento")]
        //public Evento Evento { get; set; }
    }
}