using cadastro.chamado.database;
using cadastro.chamado.Services;
using cadastro.Shared.Models;
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
        public async Task<ActionResult<IEnumerable<Chamado>>> GetChamados()
        {
            return await _context.Chamados.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Chamado>> PostChamado(Chamado chamado)
        {
            chamado.Status = "Aberto";
            chamado.DataCriacao = DateTime.Now;

            var sugestao = await _iaService.GerarSugestao(chamado.Titulo, chamado.Descricao);
            chamado.SugestaoIA = sugestao;

            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            // --- 🔔 NOTIFICAÇÃO PARA O USUÁRIO ---
            _context.Notificacoes.Add(new Notificacao
            {
                UsuarioId = chamado.UsuarioId,
                Titulo = "Chamado Criado",
                Mensagem = $"Seu chamado '{chamado.Titulo}' foi registrado com sucesso.",
                Tempo = DateTime.Now.ToString("HH:mm"),
                Tipo = "sucesso",
                Icone = "bi-check-circle"
            });

            // --- 🔔 NOTIFICAÇÃO PARA O ADMIN ---
            // Aqui marcamos como Tipo = "admin" para o filtro do dashboard administrativo
            _context.Notificacoes.Add(new Notificacao
            {
                UsuarioId = null, // Admin não precisa de ID específico ou você pode definir um ID fixo de admin
                Titulo = "Novo Chamado Recebido",
                Mensagem = $"Um novo chamado foi aberto: '{chamado.Titulo}'.",
                Tempo = DateTime.Now.ToString("HH:mm"),
                Tipo = "admin", // 👈 O SEGREDO ESTÁ AQUI
                Icone = "bi-exclamation-octagon"
            });

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChamados), new { id = chamado.Id }, chamado);
        }

        [HttpPost("sugestao")]
        public async Task<IActionResult> GerarSugestao([FromBody] SugestaoRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Titulo))
                return BadRequest("Dados insuficientes para gerar sugestão.");

            var sugestao = await _iaService.GerarSugestao(request.Titulo, request.Descricao);

            // Retornamos um objeto anônimo com a propriedade 'sugestao'
            // para bater com o que o seu Service espera
            return Ok(new { sugestao });
        }

        // Classe auxiliar para receber o JSON do frontend
        public class SugestaoRequest
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChamado(int id, [FromBody] Shared.Models.Chamado chamadoAtualizado)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null) return NotFound();

            // 1. Guardamos o estado antigo para comparar
            var statusAntigo = chamado.Status;

            // 2. Atualizamos o objeto do banco
            chamado.Status = chamadoAtualizado.Status;
            chamado.Prioridade = chamadoAtualizado.Prioridade;
            chamado.Responsavel = chamadoAtualizado.Responsavel;
            chamado.Previsao = chamadoAtualizado.Previsao;

            await _context.SaveChangesAsync();

            // --- 🔔 NOTIFICAÇÃO DE MUDANÇA DE STATUS ---
            if (statusAntigo != chamadoAtualizado.Status)
            {
                _context.Notificacoes.Add(new Notificacao
                {
                    UsuarioId = chamado.UsuarioId,
                    Titulo = "Status Atualizado",
                    Mensagem = $"O seu chamado '{chamado.Titulo}' agora está como: {chamadoAtualizado.Status}.",
                    Tempo = DateTime.Now.ToString("HH:mm"),
                    Tipo = "status", // Usamos o tipo status para o filtro do usuário
                    Icone = "🔄",
                    CriadoEm = DateTime.Now
                });
            }

            // (Mantenha as outras notificações de Prioridade e Técnico abaixo...)

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}
