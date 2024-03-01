﻿namespace TiposRelacionamentoProjeto.Models
{
    public class EnderecoModel
    {
        //Colunas
        public int Id { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }
        public int CasaId { get; set; }

        //Relacionamento
        public CasaModel Casa { get; set; }

    }
}
