﻿using System;
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
        public ProfessorController(UserManager<ApplicationUser> userManager, IProfessorRepository repo, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this.roleManager = roleManager;
            professorRepository = repo;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var professors = await _userManager.GetUsersForClaimAsync(new System.Security.Claims.Claim("IsProfessor", "true"));
            var users = _userManager.Users
                .Where(x => !professors.Any(y => y.Id == x.Id))
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
                await Setup(user);
            }

            return RedirectToAction("Index");
        }
        private async Task<IActionResult> Setup(ApplicationUser user)
        {
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsProfessor", "true"));
            professorRepository.Insert(new Entities.Professor
            {
                Id = new Guid(user.Id)
            });
            return Ok();
        }
    }
}
