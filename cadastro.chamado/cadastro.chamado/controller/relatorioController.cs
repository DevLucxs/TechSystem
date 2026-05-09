// Adicione o using do seu projeto Shared
using cadastro.chamado.database;
using cadastro.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly AppDbContext _context;

    public RelatoriosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Relatorio>>> Get()
    {
        // Certifique-se que o DbSet no AppDbContext também use <Relatorio>
        return Ok(await _context.Relatorios.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Relatorio relatorio)
    {
        if (relatorio == null) return BadRequest();

        // 1. Salva o Relatório primeiro
        _context.Relatorios.Add(relatorio);
        await _context.SaveChangesAsync();

        // 2. Cria a Notificação (Ajustado para bater com sua classe Shared)
        var novaNotificacao = new Notificacao
        {
            Tipo = "success",
            Icone = "✅", // Você adicionou esse campo na classe, então precisamos enviar!
            Titulo = "RELATORIO ENVIADO",
            Mensagem = $"Relatório '{relatorio.Titulo}' salvo.",
            Tempo = "Agora", // Campo novo da sua classe
            CriadoEm = DateTime.Now
        };

        try
        {
            _context.Notificacoes.Add(novaNotificacao);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Se o erro for só na notificação, ainda queremos que o usuário veja sucesso
            // do relatório. Então apenas logamos o erro e deixamos o código seguir.
            Console.WriteLine($"Erro ao salvar notificação: {ex.Message}");
        }

        // 3. ESSENCIAL: Retorna o objeto para o Blazor saber que deu certo!
        return Ok(relatorio);
    }
}