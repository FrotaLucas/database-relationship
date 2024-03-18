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

            //opt1
            var quarto = casa.QuartoClassDto.Select(q => new QuartoModel { Descricao = q.DescricaoDto }).ToList();
            //opt2
            //var quarto = casa.QuartoClassDto.Select(q => new QuartoModel { Descricao = q.DescricaoDto, Casa =novaCasa }).ToList();

            //op1
            var moradores = casa.MoradorClassDto.Select( m => new MoradorModel { Nomes = m.Morador }).ToList();
            //op2
            //var moradores = casa.MoradorClassDto.Select(m => new MoradorModel { Nomes = m.Morador, Casas = new List<CasaModel> {novaCasa}).ToList();
            
            novaCasa.Endereco = novoEndereco;
            novaCasa.Quartos = quarto;
            novaCasa.Moradores = moradores;

            _context.Casas.Add(novaCasa);
            await _context.SaveChangesAsync();


            return Ok( await _context.Casas.Include(e => e.Endereco).Include( q => q.Quartos).Include(m => m.Moradores).ToListAsync()  ); 
            //return Ok(await _context.Casas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCasa(int id)
        {
            // Retrieve a CasaModel instance from the database, including related EnderecoModel and QuartoModels
            CasaModel retrievedCasa = await _context.Casas
                .Include(c => c.Endereco) // Include related EnderecoModel
                .Include(c => c.Quartos)  // Include related QuartoModels
                .FirstOrDefaultAsync(c => c.Id == id);

            if (retrievedCasa == null)
            {
                return NotFound(); // Return 404 Not Found if CasaModel with the specified id is not found
            }

            // Optionally, you can create a DTO to shape the response before returning it
            var casaDto = new CasaCriacaoDto
            {

                DescricaoDto = retrievedCasa.Descricao,

                EnderecoClassDto = new EnderecoCriacaoDto
                {
                    RuaDto = retrievedCasa.Endereco.Rua,
                    NumeroDto = retrievedCasa.Endereco.Numero
                },

                QuartoClassDto = retrievedCasa.Quartos.Select(q => new QuartoCriacaoDto
                {
                    DescricaoDto = q.Descricao,
                }).ToList()


            };

            return Ok(casaDto);
        }


    }
}
