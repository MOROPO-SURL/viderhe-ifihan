using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id == ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(model.SerializedContext);

                return new Views.Placard.ClassicDeparturesPlacardView(new Models.View.Placard.ClassicOperationsSinglePlacardViewModel
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
                    TableBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor),
                    TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                    TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                    TableHeaderFontSize = context.TableHeaderFontSize,
                    PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                    PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                    SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                    SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor),
                    RowFontSize = context.RowFontSize,
                    Columns = context.Columns,
                    Background = context.Background,
                    ForegroundTransparency = context.ForegroundTransparency,
                    IsHideHeaderBuildInInfoRequired = context.IsHideHeaderBuildInInfoRequired,
                    HeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.HeaderBackgroundColor),
                    HeaderBackgroundOpacity = context.HeaderBackground == null ? 1 : context.HeaderBackgroundOpacity,
                    HeaderBackground = context.HeaderBackground,
                    LogoSizeMode = context.LogoSizeMode
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == ClassicArraivalsTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(model.SerializedContext);

                return new Views.Placard.ClassicArraivalsPlacardView(new Models.View.Placard.ClassicOperationsSinglePlacardViewModel
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
                    TableBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor),
                    TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                    TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                    TableHeaderFontSize = context.TableHeaderFontSize,
                    PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                    PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                    SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                    SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor),
                    RowFontSize = context.RowFontSize,
                    Columns = context.Columns,
                    Background = context.Background,
                    ForegroundTransparency = context.ForegroundTransparency,
                    IsHideHeaderBuildInInfoRequired = context.IsHideHeaderBuildInInfoRequired,
                    HeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.HeaderBackgroundColor),
                    HeaderBackgroundOpacity = context.HeaderBackground == null ? 1 : context.HeaderBackgroundOpacity,
                    HeaderBackground = context.HeaderBackground,
                    LogoSizeMode = context.LogoSizeMode
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == ClassicDualOperationsTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ClassicOperationsPlacardContextModel>(model.SerializedContext);

                return new Views.Placard.ClassicDualOperationsPlacardView(new Models.View.Placard.ClassicOperationsDualPlacardViewModel
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
                    TableBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableBackgroundColor),
                    TableHeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.TableHeaderBackgroundColor),
                    TableHeaderTextColor = Xamarin.Forms.Color.FromHex(context.TableHeaderTextColor),
                    TableHeaderFontSize = context.TableHeaderFontSize,
                    PrimaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowBackgroundColor),
                    PrimaryRowTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryRowTextColor),
                    SecoundaryRowBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowBackgroundColor),
                    SecoundaryRowTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryRowTextColor),
                    RowFontSize = context.RowFontSize,
                    Columns = context.Columns,
                    Background = context.Background,
                    ForegroundTransparency = context.ForegroundTransparency,
                    IsHideHeaderBuildInInfoRequired = context.IsHideHeaderBuildInInfoRequired,
                    HeaderBackgroundColor = Xamarin.Forms.Color.FromHex(context.HeaderBackgroundColor),
                    HeaderBackgroundOpacity = context.HeaderBackground == null ? 1 : context.HeaderBackgroundOpacity,
                    HeaderBackground = context.HeaderBackground,
                    LogoSizeMode = context.LogoSizeMode
                }, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}
