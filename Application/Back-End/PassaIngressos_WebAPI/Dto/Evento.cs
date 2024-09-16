using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassaIngressos_WebAPI.Dto
{
    [Table("Evento", Schema = "venda")]
    public class Evento
    {
        [Key]
        [Column("Id_Evento")]
        public int IdEvento { get; set; }

        [Column("Nome_Evento")]
        public string NomeEvento { get; set; }

        [Column("Local_Evento")]
        public string LocalEvento { get; set; }

        [Column("Data_Hora_Evento")]
        public DateTime? DataHoraEvento { get; set; }

        [Column("Id_Arquivo_Evento")]
        public int? IdArquivoEvento { get; set; }

        public List<Ingresso> Ingressos { get; set; }
    }
}