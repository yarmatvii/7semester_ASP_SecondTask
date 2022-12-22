using _7semester_ASP_SecondTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _7semester_ASP_SecondTask.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IUserStore<IdentityUser> _userStore;
		private readonly IUserEmailStore<IdentityUser> _emailStore;

		public HomeController(ILogger<HomeController> logger,
			UserManager<IdentityUser> userManager,
			IUserStore<IdentityUser> userStore)
		{
			_logger = logger;
			_userManager = userManager;
			_userStore = userStore;
			_emailStore = GetEmailStore();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> CreateUser(string e, string p)
		{
			var user = Activator.CreateInstance<IdentityUser>();

			await _userStore.SetUserNameAsync(user, e, CancellationToken.None);
			await _emailStore.SetEmailAsync(user, e, CancellationToken.None);
			await _userManager.CreateAsync(user, p);
			_userManager.Options.SignIn.RequireConfirmedAccount = false;
			return RedirectToAction("Index", "Home");
		}

		private IUserEmailStore<IdentityUser> GetEmailStore()
		{
			if (!_userManager.SupportsUserEmail)
			{
				throw new NotSupportedException("The default UI requires a user store with email support.");
			}
			return (IUserEmailStore<IdentityUser>)_userStore;
		}
	}
}