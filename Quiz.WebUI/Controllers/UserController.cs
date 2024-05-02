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
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
			_mapper = mapper;
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
		public async Task<IActionResult> Create(User user)
		{
            var userDTO = _mapper.Map<UserDTO>(user);
            await _userService.Add(userDTO);

            TempData["success"] = "Usuário criado com sucesso";
			return RedirectToAction("Index");
		}
	}
}
