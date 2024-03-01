using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiposRelacionamentoProjeto.Data;
using TiposRelacionamentoProjeto.Dtos;
using TiposRelacionamentoProjeto.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiposRelacionamentoProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairroController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BairroController(AppDbContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public async Task<IActionResult> criarCasa(CasaCriacaoDto casa)
        {
            var novaCasa = new CasaModel()
            {
                Descricao = casa.DescricaoDto,
            };

            var novoEndereco = new EnderecoModel()
            {
                Rua = casa.EnderecoClassDto.RuaDto,
                Numero = casa.EnderecoClassDto.NumeroDto,
            };

            var quarto = casa.QuartoClassDto.Select(q => new QuartoModel { Descricao = q.DescricaoDto }).ToList();
            //var quarto = casa.QuartoClassDto.Select(q => new QuartoModel { Descricao = q.Descricao, Casa =novaCasa });
           
            novaCasa.Endereco = novoEndereco;
            novaCasa.Quartos = quarto;

            _context.Casas.Add(novaCasa);
            await _context.SaveChangesAsync();

            return Ok( await _context.Casas.Include(e => e.Endereco).Include( q => q.Quartos).ToListAsync()  ); 
        }
    }
}
