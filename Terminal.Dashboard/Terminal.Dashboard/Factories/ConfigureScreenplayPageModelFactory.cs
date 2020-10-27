namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Factories
{
    public static class ConfigureScreenplayPageModelFactory
    {
        public static Models.Page.ConfigureScreenplayPageModel Build(Models.View.ScreenplayViewModel model)
        {
            if (model != null)
            {
                return new Models.Page.ConfigureScreenplayPageModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    About = model.About
                };
            }
            else
            {
                return new Models.Page.ConfigureScreenplayPageModel();
            }
        }
    }
}
