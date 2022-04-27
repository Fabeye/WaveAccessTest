using Microsoft.AspNetCore.Mvc;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccount iAccount;
        public static bool isLogged { get; set; }
        public AccountsController(IAccount iAccount)
        {
            this.iAccount = iAccount;
            isLogged = false;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Авторизация";
            if (isLogged)
            {
                ViewBag.Message = "Вы уже авторизованы (мы вам запрещаем выходить из аккаунта)";
                return RedirectToAction("Complete");
            }
            return View();
        }

        public IActionResult Registration()
        {
            ViewBag.Title = "Регистрация";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Account account)
        {
            if (ModelState.IsValid)
            {
                iAccount.createAccount(account);
                isLogged = true;
                ViewBag.Message = "Аккаунт успешно зарегистрирован";
                return RedirectToAction("Complete");
            }
            return View(account);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Вы зашли на аккаунт";
            return View(); 
        }

        public IActionResult LogIn()
        {
            ViewBag.Title = "Вход";
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(Account account)
        {
            if (ModelState.IsValid && iAccount.isCorrect(account))
            {
                isLogged = true;
                return RedirectToAction("Complete");
            }
            return View(account);
        }
    }
}
