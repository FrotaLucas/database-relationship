using System.Text.Json.Serialization;

namespace TiposRelacionamentoProjeto.Models
{
    public class MoradorModel
    {
        public int Id { get; set; }

        public string Nomes { get; set; }

        [JsonIgnore]
        public List<CasaModel> Casas { get; set; }
    }
}
