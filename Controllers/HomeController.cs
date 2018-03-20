using System;
using System.Collections.Generic;
using HikingTrails.Models;
using Microsoft.AspNetCore.Mvc;
using HikingTrails.Factory; //Need to include reference to new Factory Namespace
namespace DapperApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.Trails = userFactory.FindAll();
            return View("Index");
        }

        [HttpGet]
        [Route("/add")]
        public IActionResult Add()
        {
            return View("AddPage");
        }

        [HttpPost()]
        [Route("/check")]
        public IActionResult Check(Trail trail)
        {
            if (ModelState.IsValid)
            {
                userFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("Index", trail);
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult ShowTrail(int id)
        {
            ViewBag.trail = userFactory.GetSingleTrail(id);
            return View("Show");
        }
    }
}



