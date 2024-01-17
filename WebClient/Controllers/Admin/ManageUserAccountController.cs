using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers.Admin
{
    public class ManageUserAccountController : Controller
    {
        public IActionResult ViewUserAccount()
        {
            return View();
        }
    }
}
