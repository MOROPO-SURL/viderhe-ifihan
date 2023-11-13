namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            if (model.Template.Id == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicDeparturesPlacardContextModel>(model.SerializedContext);

                return new Views.ClassicDeparturesPlacardView(new Models.View.ClassicDeparturesPlacardViewModel
                {
                   ScreenPresentationTime = context.ScreenPresentationTime,
                   RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                   APIServer = context.APIServer,
                   AllowAnyCertificate = context.AllowAnyCertificate,
                   APIKey = context.APIKey,
                   UseSSL = context.UseSSL,
                   MaxItemsCount = context.MaxItemsCount,
                   UpdateInterval = context.UpdateInterval,
                   UseStrippedRows = context.UseStrippedRows,
                   BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor),
                   TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                   TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                   PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                   PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                   SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                   SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor)
                });
            }

            return null;
        }
    }
}
