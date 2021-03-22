using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Controllers
{
    public class AccountController : Controller
    {
        //Classe que possui os métodos para gerenciar usuário
        private readonly UserManager<IdentityUser> _userManager;

        //Classe que gerencia login e logoff
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //procura pelo usuário
                    var user = await _userManager.FindByNameAsync(model.UserName);

                    //se usuário existir
                    if(user != null)
                    {
                        //entra com a senha digitada
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                        //se tiver sucesso
                        if (result.Succeeded)
                        {
                            if (string.IsNullOrEmpty(model.ReturnUrl))
                            {
                                //retorna pra home
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                //ou para a URL que o usuário guarda
                                return Redirect(model.ReturnUrl);
                            }
                        }
                    }
                }

                //se usuário não foi encontrado, retorna erro para view
                ModelState.AddModelError("", "Usuário não encontrado");
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    //procura o usuário
                    var user = await _userManager.FindByNameAsync(model.Email);

                    //se não encontrar cria
                    if(user == null)
                    {
                        //recebendo userName
                        user = new IdentityUser()
                        {
                            UserName = model.Email,
                            Email = model.Email
                        };

                        //registrando userName com a senha
                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            //Adiciona o usuário padrão ao perfil member
                            //await _userManager.AddToRoleAsync(user, "Admin");
                            await _signInManager.SignInAsync(user, isPersistent: false);

                            return RedirectToAction("LoggedIn");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    else
                    {
                        //se usuáriofoi encontrado, retorna erro para view
                        ModelState.AddModelError("", "Usuário já existe. Faça Login");
                    }
                }

                ModelState.AddModelError("", "Erro no registro: ");
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
