namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Connect.Clients
{
    public class ComplementationsApiConnectClient
    {
        private readonly MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper;

        public ComplementationsApiConnectClient(MOROPO.SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public virtual async System.Threading.Tasks.Task EditAsync(Common.Models.ComplementationInputModel model)
        {
            await httpClientHelper.PutAsync("account/complementations", model);
        }
    }
}
