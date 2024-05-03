using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;
using Quiz.Infra.Data.Context;

namespace Quiz.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(UserDTO user)
		{
            if(user == null)
            {
                return View(user);
            }
            if(user == null)
            {
                return View(user);
            }
            await _userService.Add(user);

            TempData["success"] = "Usuário criado com sucesso";
			return RedirectToAction("Index");
		}
	}
}
