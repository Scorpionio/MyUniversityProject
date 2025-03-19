using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class CatalogController : Controller
    {
        ApplicationDbContext db;
        public CatalogController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var model = new ViewModel
            {
                Processors = db.Processors.ToList(),
                GraphicCards = db.GraphicCard.ToList()
            };
            if (User.Identity.Name == "admin")
            {
                ViewData["HiddenUser"] = "display: block;";
                ViewData["User"] = $"{User.Identity.Name}";
                ViewData["Hidden"] = "display: inline-block;";
                return View(model);

            }
            else if (User.Identity.Name != "admin" && User.Identity.Name != null)
            {
                ViewData["HiddenUser"] = "display: block;";
                ViewData["User"] = $"{User.Identity.Name}";
                ViewData["Hidden"] = "display: none;";
                return View(model);
            }
            ViewData["HiddenUser"] = "display: none;";
            ViewData["Hidden"] = "display: none;";
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new ViewModel
            {
                Processors = db.Processors.ToList(),
                GraphicCards = db.GraphicCard.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcessor(Processor processor)
        {
            if (ModelState.IsValid) {
                db.Processors.Add(processor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView("CreateProcessor", processor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGraphicCard(GraphicCard graphicsCard)
        {
            if (ModelState.IsValid) { 
                db.GraphicCard.Add(graphicsCard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView("CreateGraphicCard", graphicsCard);
            }
            //asp-controller="Home" asp-action="Privacy"

        public IActionResult GraphicCardDetails(int id) {
            var GraphicCard = db.GraphicCard.Find(id);
            return View(GraphicCard);
        }

        public IActionResult ProcessorDetails(int id)
        {
            var Processor = db.Processors.Find(id);
            return View(Processor);
        }
        public IActionResult DeleteItem(int id)
        {
            var Device = db.Device.Find(id);
            if (Device != null) { 
                db.Device.Remove(Device);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditProcessor(int id)
        {
            var processor = db.Device.Find(id);
            return View(processor);
        }
        public IActionResult UpdateProcessor(Processor processor)
        {
            db.Processors.Update(processor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditGraphicCard(int id)
        {
            var graphicCard = db.Device.Find(id);
            return View(graphicCard);
        }
        public IActionResult UpdateGraphicCard(GraphicCard graphicCard)
        {
            db.GraphicCard.Update(graphicCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
