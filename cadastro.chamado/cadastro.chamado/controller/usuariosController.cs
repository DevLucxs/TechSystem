using cadastro.chamado.database;
using cadastro.chamado.models; // ← ESSENCIAL
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


namespace cadastro.chamado.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/usuarios (cadastro)
        [HttpPost]
        public async Task<ActionResult<Usuario>> CriarUsuario(Usuario usuario)
        {
            // Criptografa a senha antes de salvar
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarUsuario), new { id = usuario.Id }, usuario);
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(LoginRequest request)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
            {
                return Unauthorized("Email ou senha inválidos");
            }

            return Ok(usuario); // aqui você pode gerar JWT se quiser
        }
    }

}
