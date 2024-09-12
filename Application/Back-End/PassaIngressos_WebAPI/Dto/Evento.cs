using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Evento", Schema = "venda")]
    public class Evento
    {
        [Key]
        [Column("Id_Evento")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Local")]
        public string Local { get; set; }

        [Column("DataHoraEvento")]
        public DateTime? DataHoraEvento { get; set; }
    }
}