using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporArt.Services;

namespace SporArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviarEmailController : ControllerBase
    {
        [HttpPost("enviar")]
        public async Task<IActionResult> Enviar()
        {
            var emailService = new EmailService();
            var destinatarios = new List<string>();
            destinatarios.Add("mario.cleber@sp.senai.br");
            var assunto = "Aula email";

            var remetente = "mario.cleber@docente.senai.br";

            var mensagem = "Ola! Este é um email de teste";

            await emailService.Send(destinatarios, assunto, mensagem, remetente);

            return Ok("Email enviado com sucesso");
        }
    }
}
