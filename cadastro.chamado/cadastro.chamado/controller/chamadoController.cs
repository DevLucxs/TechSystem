using cadastro.chamado.database;
using cadastro.chamado.models;
using cadastro.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro.chamado.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IaService _iaService;

        public ChamadoController(AppDbContext context, IaService iaService)
        {
            _context = context;
            _iaService = iaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Chamado>>> GetChamados()
        {
            return await _context.Chamados.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<models.Chamado>> PostChamado(models.Chamado chamado)
        {
            chamado.Status = "Aberto";
            chamado.DataCriacao = DateTime.Now;

            // 👇 chama a IA para sugerir uma ação inicial
            var sugestao = await _iaService.GerarSugestao(chamado.Titulo, chamado.Descricao);
            chamado.SugestaoIA = sugestao; // precisa ter esse campo no model Chamado

            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChamados), new { id = chamado.Id }, chamado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChamado(int id, [FromBody] Shared.Chamado chamadoAtualizado)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null) return NotFound();

            // Atualiza apenas os campos que podem mudar
            chamado.Status = chamadoAtualizado.Status;
            chamado.Prioridade = chamadoAtualizado.Prioridade;
            chamado.Previsao = chamadoAtualizado.Previsao;
            chamado.Responsavel = chamadoAtualizado.Responsavel;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarChamado(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null) return NotFound();

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 👇 Novo endpoint para gerar sugestão sem criar chamado
        [HttpPost("sugestao")]
        public async Task<IActionResult> GerarSugestao([FromBody] SugestaoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Descricao))
                return BadRequest("Título e descrição são obrigatórios.");

            var sugestao = await _iaService.GerarSugestao(request.Titulo, request.Descricao);
            return Ok(new { sugestao });
        }



    }

}
