﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleTheaterTickets.Models;
using System;
using System.Threading.Tasks;

namespace SaleTheaterTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                //ReturnUrl = Request.Headers["Referer"].ToString()
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //procura pelo usuário
                    var user = await _userManager.FindByNameAsync(model.Email);

                    //se usuário existir
                    if (user != null)
                    {
                        if (model.Password != user.PasswordHash)
                        {
                            ModelState.AddModelError("", "Senha incorreta!");
                        }

                        //entra com a senha digitada
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                        //se tiver sucesso
                        if (result.Succeeded)
                        {
                            if (string.IsNullOrEmpty(model.ReturnUrl))
                            {
                                //retorna pra home
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                //ou para a URL que o usuário guarda
                                return Redirect(model.ReturnUrl);
                            }
                        }

                        //ModelState.AddModelError("", "Senha incorreta!");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não encontrado. Registre-se");
                        return View(model);
                    }
                }

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
                    if (user == null)
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
                            //Adiciona o usuário padrão ao perfil Admin
                            await _userManager.AddToRoleAsync(user, "Admin");
                            await _signInManager.SignInAsync(user, isPersistent: false);

                            return RedirectToAction("Index", "Admin");
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

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area = ""});
        }

        public ActionResult LoggedIn()
        {
            return View();
        }
    }
}
