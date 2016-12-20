using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace QuizH.ViewModels.Professor
{
    public class UserViewModel
    {
        public string Id { get; set;}
        public string UserName { get; set; }
        public bool IsProfessor { get; set; }
    }
    public class UnasignedUsersListViewModel
    {
        public List<UserViewModel> Users { get; set; }
    }
}
