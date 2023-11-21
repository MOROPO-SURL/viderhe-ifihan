using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Factories
{
    public static class ClassicDeparturesPlacardConfigurationPageModelFactory
    {
        public static Models.Page.ClassicDeparturesPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.ClassicDeparturesPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicDeparturesPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.ClassicDeparturesPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? Common.Templating.Dashboard.Presentation.Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                APIServer = context.APIServer,
                APIKey = context.APIKey,
                UseSSL = context.UseSSL,
                AllowAnyCertificate = context.AllowAnyCertificate,
                UpdateInterval = context.UpdateInterval,
                MaxItemsCount = context.MaxItemsCount,
                BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor),
                TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                TableHeaderFontSize = context.TableHeaderFontSize,
                PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                UseStrippedRows = context.UseStrippedRows,
                SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor),
                SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                RowFontSize = context.RowFontSize,
                Columns = new System.Collections.ObjectModel.ObservableCollection<Enumerations.ClassicDeparturesColumn>(context.Columns)
            };
        }
    }
}
