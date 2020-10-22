namespace SmartSolucionesCuba.Videre.Cloud.Controllers
{
    public class StartController : Microsoft.AspNetCore.Mvc.Controller
    {
        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            return Redirect("management/dashboard");
        }
    }
}
