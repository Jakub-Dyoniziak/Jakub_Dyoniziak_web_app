using Jakub_Dyoniziak_web_app.Constants;
using Jakub_Dyoniziak_web_app.Data;
using Jakub_Dyoniziak_web_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Jakub_Dyoniziak_web_app.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var surveys = await _context.Surveys.ToListAsync();
            return View(surveys);
        }

        public async Task<IActionResult> Details(int id)
        {
            var survey = await _context.Surveys
                .Include(s => s.Options)
                .ThenInclude(o => o.Votes)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (survey == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.HasVoted = survey.Options
                .SelectMany(o => o.Votes)
                .Any(v => v.UserId == userId);

            return View(survey);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Respondent)]
        public async Task<IActionResult> Vote(int optionId)
        {
            var user = await _userManager.GetUserAsync(User);

            var option = await _context.Options
                .Include(o => o.Survey)
                .FirstOrDefaultAsync(o => o.Id == optionId);

            if (option == null)
                return NotFound();

            var surveyId = option.SurveyId;

            var alreadyVoted = await _context.Votes
                .AnyAsync(v => v.UserId == user.Id &&
                               v.Option.SurveyId == surveyId);

            if (alreadyVoted)
            {
                return Content("Już głosowałeś w tej ankiecie.");
            }

            var vote = new Vote
            {
                OptionId = optionId,
                UserId = user.Id
            };

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = Roles.Ankieter)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Roles.Ankieter)]
        public async Task<IActionResult> Create(Survey survey, string[] options)
        {
            if (ModelState.IsValid)
            {
                foreach (var opt in options)
                {
                    survey.Options.Add(new Option { Text = opt });
                }

                _context.Surveys.Add(survey);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(survey);
        }

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public SurveyController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
