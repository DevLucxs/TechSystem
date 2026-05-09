using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cadastro.Shared.Models; // IMPORTANTE: Agora aponta para o Shared
using cadastro.chamado.database;

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
        public async Task<ActionResult<IEnumerable<Notificacao>>> Get()
        {
            // O segredo aqui é garantir que o retorno seja a lista da classe do Shared
            var lista = await _context.Notificacoes.ToListAsync();
            return Ok(lista); // O Ok() ajuda o ASP.NET a converter para ActionResult corretamente
        }


        [HttpPost]
        public async Task<ActionResult<Notificacao>> Post(Notificacao notificacao)
        {
            _context.Notificacoes.Add(notificacao);
            await _context.SaveChangesAsync();
            return Ok(notificacao);
        }



        [HttpPost("ler-todas/{usuarioId}")]
        public async Task<IActionResult> MarcarTodasComoLidas(int usuarioId)
        {
            // Exemplo de lógica se você usar Entity Framework:
            var notificacoes = await _context.Notificacoes
                .Where(n => n.UsuarioId == usuarioId && !n.Lida)
                .ToListAsync();

            foreach (var n in notificacoes)
            {
                n.Lida = true;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}