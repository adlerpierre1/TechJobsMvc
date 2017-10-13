using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }


        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm) //method created with two parameters
        {
            ViewBag.columns = ListController.columnChoices; //creates a view of the columns with the job information

            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>(); //must put that the jobs are a list within a dictionary

            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }
            if (searchType.Equals("all")) //supposed to return all :/
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else //if anything else, then find the job values through the type and term 
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }
        }
    }
}
