using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using QueroTransporteWeb.Resources.Methods;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QueroTransporteWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly GerenciadorUsuario _gerenciadoraUsuario;
        public LoginController(GerenciadorUsuario gerenciadoraUsuario)
        {
            _gerenciadoraUsuario = gerenciadoraUsuario;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Autenticar(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _gerenciadoraUsuario.ObterPorLoginSenha(MethodsUtils.RemoverCaracteresEspeciais(model.Cpf), Criptografia.GerarHashSenha(model.Senha));
                Console.WriteLine(Criptografia.GerarHashSenha(model.Senha));
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Nome),
                        new Claim(ClaimTypes.UserData, user.Cpf),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.OtherPhone, user.Telefone),
                        new Claim(ClaimTypes.Role, user.Tipo)
                    };

                    // Adicionando uma identidade as claims.
                    var identidade = new ClaimsIdentity(claims, "login");

                    // Propriedades da autenticação.
                    var propriedadesClaim = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1) // Expira em 1 dia
                    };

                    // Logando efetivamente.
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identidade), propriedadesClaim);

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Login", new { msg = "error" });
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUser(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                // Informações do objeto
                usuario.Cpf = MethodsUtils.RemoverCaracteresEspeciais(usuario.Cpf);
                usuario.Senha = Criptografia.GerarHashSenha(usuario.Senha);
                usuario.Tipo = "CLIENTE";

                if (_gerenciadoraUsuario.Inserir(usuario))
                    return RedirectToAction("Autenticar", "Login");
            }
            return View(usuario);
        }

        [Authorize]
        public ActionResult AcessoNegado()
        {
            return View();
        }
    }
}