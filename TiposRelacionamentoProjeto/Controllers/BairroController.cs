using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiposRelacionamentoProjeto.Data;

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
        public async Task<IActionResult> criarCasa()
        {

        }
    }
}
