using Microsoft.AspNetCore.Mvc;
using GerenciarArmazen.Models;
using GerenciarArmazen.MeuContexto;

namespace GerenciarArmazen.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _context;

        public LoginController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuario.SingleOrDefault(u => u.Email == model.Email);

                if (usuario != null && VerificarSenha(usuario.Senha, model.Senha))
                {
                    // Autenticar o usuário e redirecionar para a página desejada
                    return RedirectToAction("Index", "Pedidos2");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
                }
            }

            return View(model);
        }

        private bool VerificarSenha(string senhaArmazenada, string senhaDigitada)
        {
            // Implemente aqui a lógica para verificar se a senha digitada é válida
            // Você pode usar uma biblioteca de hashing, como o BCrypt, para comparar as senhas de forma segura

            // Exemplo simples de comparação de senhas (não seguro para uso em produção)
            return senhaArmazenada == senhaDigitada;
        }
    }
}
