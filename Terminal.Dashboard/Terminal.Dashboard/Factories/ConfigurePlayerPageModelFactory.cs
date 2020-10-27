namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Factories
{
    public static class ConfigurePlayerPageModelFactory
    {
        public static Models.Page.ConfigurePlayerPageModel Build(Models.View.PlayerViewModel model)
        {
            if (model != null)
            {
                return new Models.Page.ConfigurePlayerPageModel
                {
                    IsBusy = true,
                    Id = model.Id,
                    Name = model.Name,
                    Screenplay = model.Screenplay,
                    About = model.About
                };
            }
            else
            {
                return new Models.Page.ConfigurePlayerPageModel
                {
                    IsBusy = true
                };
            }
        }
    }
}
