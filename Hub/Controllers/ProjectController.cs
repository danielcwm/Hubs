using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hub.Models;
using Hub.Models.Dbcontext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hub.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DomainDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ProjectController()
        {
            _context = new DomainDbContext();
            
        }

        // GET: AddProject -> Return signle project
        public ActionResult AddProject()
        {
            return View();
        }

        public ActionResult Porject(int id)
        {
            return View("AddProject");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(Project project)
        {
            var t = new Tag(){ Name = "new tag"};
            var p = new Project
            {
                Title = "new title",
                Description = "Desc",
                ContactEmail = "email",
                VisitedCount = 1,
                Liked = 1,
                DateCreated = DateTime.Today,
                Tag = new List<Tag>()
                {
                    t
                }
            };
            var userId = User.Identity.GetUserId();

            _context.Projects.Add(p);
            _context.SaveChanges();
            return View("AddProject");
        }

    }
}