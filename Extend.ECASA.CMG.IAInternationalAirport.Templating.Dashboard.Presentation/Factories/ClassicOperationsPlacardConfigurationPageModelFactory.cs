using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Factories
{
    public static class ClassicOperationsPlacardConfigurationPageModelFactory
    {
        public static Models.Page.ClassicOperationsPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.ClassicOperationsPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.ClassicOperationsPlacardConfigurationPageModel
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
                TableBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor),
                TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                TableHeaderFontSize = context.TableHeaderFontSize,
                PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                UseStrippedRows = context.UseStrippedRows,
                SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor),
                SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                VisibleColumns = new System.Collections.ObjectModel.ObservableCollection<Models.View.ClassicOperationColumnCollectionItemViewModel>(),
                RowFontSize = context.RowFontSize,
                Background = context.Background,
                ForegroundTransparency = context.ForegroundTransparency
            };

            var index = 0;

            foreach (var item in context.Columns)
            {
                result.VisibleColumns.Add(new Models.View.ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = item });
            }

            return result;
        }
    }
}
