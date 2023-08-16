namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories
{
    public static class HeroLocalNowDateTimePlacardConfigurationPageModelFactory
    {
        public static Models.Page.HeroLocalNowDateTimePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.HeroLocalNowDateTimePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.HeroLocalNowDateTimePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                Style = context.Style,
                IsDateTimeFramed = context.IsDateTimeFramed,
                Background = context.Background,
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                TextFontFamily = context.TextFontFamily
            };

            foreach (var item in result.AvailableCultures)
            {
                if (context.Culture.Equals(item.ToString())) break;

                result.CultureIndex++;
            }

            return result;
        }
    }
}
