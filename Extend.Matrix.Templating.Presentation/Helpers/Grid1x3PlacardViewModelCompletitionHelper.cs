using SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using System.Collections.Generic;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Helpers
{
    public class Grid1x3PlacardViewModelCompletitionHelper : Common.Templating.Presentation.Helpers.Facade.IPlacardViewModelCompletitionHelperFacade
    {
        public async System.Threading.Tasks.Task CompleteAsync(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid1x3PlacardContextModel>(model.SerializedContext);

            var apiConnectClient = new PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var transformedOneOfThreeTargetPlacards = new List<object>();
            var transformedTwoOfThreeTargetPlacards = new List<object>();
            var transformedThreeOfThreeTargetPlacards = new List<object>();

            foreach (var item in context.OneOfThreeTargetPlacards)
            {
                var placardId = (System.Guid) item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedOneOfThreeTargetPlacards.Add(placard.ToViewModel());
            }

            foreach (var item in context.TwoOfThreeTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedTwoOfThreeTargetPlacards.Add(placard.ToViewModel());
            }

            foreach (var item in context.ThreeOfThreeTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedThreeOfThreeTargetPlacards.Add(placard.ToViewModel());
            }

            context.OneOfThreeTargetPlacards = transformedOneOfThreeTargetPlacards.ToArray();
            context.TwoOfThreeTargetPlacards = transformedTwoOfThreeTargetPlacards.ToArray();
            context.ThreeOfThreeTargetPlacards = transformedThreeOfThreeTargetPlacards.ToArray();

            model.SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(context);
        }
    }
}
