using System.Text.Json.Serialization;

namespace TiposRelacionamentoProjeto.Models
{
    public class QuartoModel
    {
        //Colunas 
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int CasaId { get; set; }

        //Relacionamento
        [JsonIgnore]
        public CasaModel Casa { get; set; }
    }
}
