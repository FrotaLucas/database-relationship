namespace TiposRelacionamentoProjeto.Models
{
    public class CasaModel
    {
        //Colunas
        public int Id { get; set; }
        public string Descricao { get; set; }

        //Relacionamento
        public List<QuartoModel> Quartos { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<MoradorModel> Moradores { get; set; } 

    }
}
