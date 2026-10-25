namespace MOROPO.VIDERHE.Cloud.Extensions
{
    public static class ManagementDashboardSectionExtensions
    {
        public static Microsoft.AspNetCore.Html.HtmlString ToIconographyHtmlString(this Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel target)
        {
            if (target.Controller == "users") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-user");

            if (target.Controller == "roles") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-users");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-book");

            return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-cog");
        }
    }
}
