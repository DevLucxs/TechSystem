using cadastro.chamado.database;
using cadastro.chamado.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro.chamado.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacaoDto>>> Get()
        {
            var notificacoes = await _context.Notificacoes
                .OrderByDescending(n => n.CriadoEm)
                .ToListAsync();

            return Ok(notificacoes);
        }
    }
}
