using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizH.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizH.Controllers
{
    using DAL;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using ViewModels.Professor;
    public class ProfessorController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfessorRepository professorRepository;
        public ProfessorController(UserManager<ApplicationUser> userManager,IProfessorRepository repo)
        {
            _userManager = userManager;
            professorRepository = repo; 
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = _userManager.Users
                .Where(x => x.Claims.All(y=>y.ClaimType != "Professor"))
                .Select(x => new UserViewModel { Id = x.Id, UserName = x.UserName })
                .ToList();
            var vm = new UnasignedUsersListViewModel()
            {
                Users = users
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Assign(List<UserViewModel> professors)
        {
            var choosen = professors.Where(x => x.IsProfessor);
            foreach (var professor in choosen)
            {
                var user = _userManager.Users.First(x => x.Id == professor.Id);

                var result = await _userManager.AddClaimAsync(user, new Claim("IsProfessor", "true"));
                if (result.Succeeded)
                {
                    return View();
                }

                professorRepository.Insert(new Entities.Professor() { Id = new Guid(professor.Id) });
            }
            
            return View();
        }
    }
}
