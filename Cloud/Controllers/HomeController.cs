namespace MOROPO.VIDERHE.Cloud.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            return Redirect("management/dashboard");
        }
    }
}
