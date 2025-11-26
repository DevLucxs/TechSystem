using cadastro.chamado.database;
using cadastro.chamado.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro.chamado.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/relatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioDto>>> Get()
        {
            return Ok(await _context.Relatorios.ToListAsync());
        }

        // POST /api/relatorios
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] RelatorioDto relatorio)
        {
            _context.Relatorios.Add(relatorio);
            await _context.SaveChangesAsync();

            // cria notificação automática
            _context.Notificacoes.Add(new NotificacaoDto
            {
                Tipo = "sucesso",
                Icone = "✅",
                Titulo = "Relatório enviado com sucesso",
                Mensagem = $"Relatório '{relatorio.Titulo}' foi salvo.",
                Tempo = "Agora",
                CriadoEm = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return Ok(relatorio);
        }
    }
}
