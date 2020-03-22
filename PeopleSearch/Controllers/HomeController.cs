using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonContext _context;

        public HomeController(PersonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResult(string searchValue = null)
        {
            List<Person> personList;
            if (string.IsNullOrEmpty(searchValue))
            {
                personList = _context.Person.ToList();

                //Clear database for testing
                //foreach (Person p in personList)
                //{
                //    _context.Person.Remove(p);
                //}
                //_context.SaveChanges();
            }
            else
            {
                personList = _context.Person
                    .Where(m => m.FullName.Contains(searchValue))
                    .ToList();
            }
            return View(personList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Take Home evaluation for Health Catalyst";

            return View();
        }
    }
}
