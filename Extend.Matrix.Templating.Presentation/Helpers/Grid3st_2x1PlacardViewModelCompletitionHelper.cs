namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Helpers
{
    public class Grid3st_2x1PlacardViewModelCompletitionHelper : Common.Templating.Presentation.Helpers.Facade.IPlacardViewModelCompletitionHelperFacade
    {
        public async System.Threading.Tasks.Task CompleteAsync(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid3st_2x1PlacardContextModel>(model.SerializedContext);

            var apiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var transformedOneOfTwoTargetPlacards = new System.Collections.Generic.List<object>();
            var transformedTwoOfTwoSplitOneOfTwoTargetPlacards = new System.Collections.Generic.List<object>();
            var transformedTwoOfTwoSplitTwoOfTwoTargetPlacards = new System.Collections.Generic.List<object>();

            foreach (var item in context.OneOfTwoTargetPlacards)
            {
                var placardId = System.Guid.Parse(item as string);

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedOneOfTwoTargetPlacards.Add(placard);
            }

            foreach (var item in context.TwoOfTwoSplitOneOfTwoTargetPlacards)
            {
                var placardId = System.Guid.Parse(item as string);

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedTwoOfTwoSplitOneOfTwoTargetPlacards.Add(placard);
            }

            foreach (var item in context.TwoOfTwoSplitTwoOfTwoTargetPlacards)
            {
                var placardId = System.Guid.Parse(item as string);

                var placard = await apiConnectClient.GetAsync(placardId);

                transformedTwoOfTwoSplitTwoOfTwoTargetPlacards.Add(placard);
            }

            context.OneOfTwoTargetPlacards = transformedOneOfTwoTargetPlacards.ToArray();
            context.TwoOfTwoSplitOneOfTwoTargetPlacards = transformedTwoOfTwoSplitOneOfTwoTargetPlacards.ToArray();
            context.TwoOfTwoSplitTwoOfTwoTargetPlacards = transformedTwoOfTwoSplitTwoOfTwoTargetPlacards.ToArray();

            model.SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(context);
        }
    }
}
