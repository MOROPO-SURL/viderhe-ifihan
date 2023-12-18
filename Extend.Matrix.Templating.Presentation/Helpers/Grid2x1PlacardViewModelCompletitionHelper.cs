namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Helpers
{
    public class Grid2x1PlacardViewModelCompletitionHelper : Common.Templating.Presentation.Helpers.Facade.IPlacardViewModelCompletitionHelperFacade
    {
        public async System.Threading.Tasks.Task CompleteAsync(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid2x1PlacardContextModel>(model.SerializedContext);

            var apiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var transformedOneOfTwoTargetPlacards = new System.Collections.Generic.List<object>();
            var transformedTwoOfTwoTargetPlacards = new System.Collections.Generic.List<object>();

            foreach (var item in context.OneOfTwoTargetPlacards)
            {
                var placardId = System.Guid.Parse(item as string);

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedOneOfTwoTargetPlacards.Add(placard);
            }

            foreach (var item in context.TwoOfTwoTargetPlacards)
            {
                var placardId = System.Guid.Parse(item as string);

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedTwoOfTwoTargetPlacards.Add(placard);
            }

            context.OneOfTwoTargetPlacards = transformedOneOfTwoTargetPlacards.ToArray();
            context.TwoOfTwoTargetPlacards = transformedTwoOfTwoTargetPlacards.ToArray();

            model.SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(context);
        }
    }
}
