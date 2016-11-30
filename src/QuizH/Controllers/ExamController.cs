using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels;
using Entities;
using DAL;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizH.Controllers
{
    public class InMemoryExams
    {
        public static List<Exam> Exams = new List<Exam>();
    }
    public class ExamController : Controller
    {
        CourseRepository courses;
        QuestionRepository questions;
        ExamRepository exams;
        public ExamController()
        {
            courses = new CourseRepository();
            exams = new ExamRepository();
            questions = new QuestionRepository();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new ExamListViewModel()
            {
                Exams = exams.GetAll().Select(x => new ExamDetailsViewModel() {
                    Title = x.Title,
                    Instructions = x.Instructions,
                    Course = x.Course.Title
                })
            });
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View(new ExamCreationViewModel()
            {
                AvailableCourses = courses.GetAll().Select(x => x.Title).ToList(),
                AvailableQuestions = questions.GetAll().Select(x=> x.Text).ToList()
            });
        }
        [HttpPost]
        public IActionResult Insert(ExamCreationViewModel examVM)
        {
            var exam = new Exam
            {
                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),

            };

            exam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.Text)));

            exams.Insert(exam);
            return RedirectToAction("Index");
        }
    }
}
