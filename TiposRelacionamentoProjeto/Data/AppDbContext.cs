using Microsoft.EntityFrameworkCore;
using TiposRelacionamentoProjeto.Models;

namespace TiposRelacionamentoProjeto.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<CasaModel> Casas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        //ATENCAO Tabela de quarto foi criada sem colocar antes aqui ela coforme
        //foi feitas com as tabelas Casas e Endereços. Por isso a tabela Quartos se chama
        //QuartoModel

        public DbSet<MoradorModel> Morador { get; set;}

        //Como tabela MOrador tem realcionamento n-n com casa, uma tabela intermediaria
        //sera criada automaticamente. Se chama Casa Model Morador Model
        
    }
}
