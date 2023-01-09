using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using System.Collections.Generic;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Helpers
{
    public class Grid2x2PlacardViewModelCompletitionHelper : Common.Templating.Presentation.Helpers.Facade.IPlacardViewModelCompletitionHelperFacade
    {
        public async System.Threading.Tasks.Task CompleteAsync(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid2x2PlacardContextModel>(model.SerializedContext);

            var apiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var transformedOneOfFourTargetPlacards = new List<object>();
            var transformedTwoOfFourTargetPlacards = new List<object>();
            var transformedThreeOfFourTargetPlacards = new List<object>();
            var transformedFourOfFourTargetPlacards = new List<object>();

            foreach (var item in context.OneOfFourTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedOneOfFourTargetPlacards.Add(placard.ToViewModel());
            }

            foreach (var item in context.TwoOfFourTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedTwoOfFourTargetPlacards.Add(placard.ToViewModel());
            }

            foreach (var item in context.ThreeOfFourTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedThreeOfFourTargetPlacards.Add(placard.ToViewModel());
            }

            foreach (var item in context.FourOfFourTargetPlacards)
            {
                var placardId = (System.Guid)item;

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedFourOfFourTargetPlacards.Add(placard.ToViewModel());
            }

            context.OneOfFourTargetPlacards = transformedOneOfFourTargetPlacards.ToArray();
            context.TwoOfFourTargetPlacards = transformedTwoOfFourTargetPlacards.ToArray();
            context.ThreeOfFourTargetPlacards = transformedThreeOfFourTargetPlacards.ToArray();
            context.FourOfFourTargetPlacards = transformedFourOfFourTargetPlacards.ToArray();

            model.SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(context);
        }
    }
}
