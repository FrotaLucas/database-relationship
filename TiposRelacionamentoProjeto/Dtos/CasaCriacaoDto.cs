namespace TiposRelacionamentoProjeto.Dtos
{
    public class CasaCriacaoDto
    {
        public string DescricaoDto { get; set; }
        public EnderecoCriacaoDto EnderecoClassDto { get; set; }

        public List<QuartoCriacaoDto> QuartoClassDto { get; set; }

        public List<MoradoresCrracaoDto> MoradorClassDto { get; set; }
    }
}
