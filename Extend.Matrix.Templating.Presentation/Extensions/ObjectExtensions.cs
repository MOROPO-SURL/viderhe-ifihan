using MOROPO.VIDERHE.Support.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Extensions
{
    public static class ObjectExtensions
    {
        public static Support.Presentation.Models.View.PlacardViewModel ToPlacardViewModel(this object target)
        {
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Cloud.Api.Common.Models.PlacardDisplayModel>(Newtonsoft.Json.JsonConvert.SerializeObject(target));

            return model.ToViewModel();
        }
    }
}
