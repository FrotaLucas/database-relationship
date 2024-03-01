namespace TiposRelacionamentoProjeto.Models
{
    public class MoradorModel
    {
        public int Id { get; set; }

        public string Nomes { get; set; }

        public List<CasaModel> Casas { get; set; }
    }
}
