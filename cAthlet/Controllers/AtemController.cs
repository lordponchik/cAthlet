using cAthlet.Data;
using cAthlet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace cAthlet.Controllers
{
    [Authorize]
    public class AtemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AtemController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var settings = await _context.AtemEinstellungen
                .FirstOrDefaultAsync(s => s.BenutzerId == user.Id)
                ?? new AtemEinstellungen
                {
                    EinatmenSekunden = 4,
                    AnhaltenSekunden = 4,
                    AusatmenSekunden = 4,
                    PauseSekunden = 4,
                    GesamtMinuten = 3
                };

            return View(settings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AtemEinstellungen input)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            ModelState.Remove("BenutzerId");

            if (!ModelState.IsValid)
            {
                var relevantErrors = ModelState
                    .Where(entry => entry.Key != "BenutzerId" && entry.Value.Errors.Any())
                    .SelectMany(entry => entry.Value.Errors.Select(error => $"{entry.Key}: {error.ErrorMessage}"));

                if (relevantErrors.Any())
                {
                    TempData["FormErrors"] = string.Join("\n", relevantErrors);
                    return View(input);
                }
            }

            var existingSettings = await _context.AtemEinstellungen.FirstOrDefaultAsync(s => s.BenutzerId == user.Id);
            if (existingSettings != null)
            {
                existingSettings.BenutzerId = user.Id;

                existingSettings.EinatmenSekunden = input.EinatmenSekunden;
                existingSettings.AnhaltenSekunden = input.AnhaltenSekunden;
                existingSettings.AusatmenSekunden = input.AusatmenSekunden;
                existingSettings.PauseSekunden = input.PauseSekunden;
                existingSettings.GesamtMinuten = input.GesamtMinuten;
            }
            else
            {
                input.BenutzerId = user.Id;
                _context.AtemEinstellungen.Add(input);
            }

            var session = new AtemSitzung
            {
                BenutzerId = user.Id,
                EinatmenSekunden = input.EinatmenSekunden,
                AnhaltenSekunden = input.AnhaltenSekunden,
                AusatmenSekunden = input.AusatmenSekunden,
                PauseSekunden = input.PauseSekunden,
                GesamtMinuten = input.GesamtMinuten,
                AbgeschlossenAm = DateTime.UtcNow
            };
            _context.AtemSitzung.Add(session);

            await _context.SaveChangesAsync();

            return RedirectToAction("Exercise", new
            {
                EinatmenSekunden = input.EinatmenSekunden,
                AnhaltenSekunden = input.AnhaltenSekunden,
                AusatmenSekunden = input.AusatmenSekunden,
                PauseSekunden = input.PauseSekunden,
                GesamtMinuten = input.GesamtMinuten
            });
        }

        [HttpGet]
        public IActionResult Exercise(int EinatmenSekunden, int AnhaltenSekunden, int AusatmenSekunden, int PauseSekunden, int GesamtMinuten)
        {
            var model = new AtemEinstellungen
            {
                EinatmenSekunden = EinatmenSekunden,
                AnhaltenSekunden = AnhaltenSekunden,
                AusatmenSekunden = AusatmenSekunden,
                PauseSekunden = PauseSekunden,
                GesamtMinuten = GesamtMinuten
            };
            return View(model);
        }
    }
}
