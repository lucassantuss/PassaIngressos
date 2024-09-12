using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Ingresso", Schema = "venda")]
    public class TipoIngresso
    {
        [Key]
        [Column("Id_Tipo_Ingresso")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
    }
}