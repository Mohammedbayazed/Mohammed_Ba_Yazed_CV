using Microsoft.AspNetCore.Mvc;
using AboutMe.Models;
using System.Diagnostics;

namespace AboutMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Log the contact form submission
                _logger.LogInformation($"Contact form submitted by: {model.Name} ({model.Email})");

                // In production, you would send an email here
                // Example: _emailService.SendEmail(model);

                TempData["SuccessMessage"] = "Thank you! Your message has been sent successfully.";
                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

        public IActionResult DownloadCV()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "files", "CV.pdf");

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", "CV.pdf");
            }

            return NotFound("CV file not found.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}