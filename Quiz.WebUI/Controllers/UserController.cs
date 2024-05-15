using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;
using Quiz.Infra.Data.Context;
using Quiz.WebUI.Filters;

namespace Quiz.WebUI.Controllers
{
    [RestrictedPageAdmin]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Index()
        {
			UserQuestionDTO userQuestion = new UserQuestionDTO();
            var users = await _userService.GetUsers();
            return View(users);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

        [HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(UserDTO user)
        {
            try
            {
				if (ModelState.IsValid)
				{
					await _userService.Add(user);

					TempData["success"] = "Usuário criado com sucesso";
					return RedirectToAction("Index");
				}

				TempData["error"] = "Error for create a user";
				return View(user);
			}
            catch
            {
				TempData["error"] = "Error for create a user";
				return View(user);
            }
		}

		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			try
			{
                var user = await _userService.GetById(id);
				if(user == null)
				{
					return NotFound();
				}
                return View(user);
            }
			catch
			{

				return NotFound();
			}

		}
		[HttpPost]
		public async Task<IActionResult> Update(UserDTO userDTO)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    await _userService.Update(userDTO);
                    TempData["success"] = "User updated successfuly";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Error edit a user";
                return View(userDTO);
			}
			catch
			{
                TempData["error"] = "Error edit a user";
                return View(userDTO);
			}

		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		
		{
			var resultado = await _userService.GetById(id);
			return View(resultado);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(int? id)
		{
			await _userService.Remove(id);
			TempData["success"] = "User deleted successfuly";
			return RedirectToAction("Index");
		}
	}
}
