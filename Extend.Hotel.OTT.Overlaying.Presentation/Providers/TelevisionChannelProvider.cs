using System.Collections.Generic;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Providers
{
    public sealed class TelevisionChannelProvider
    {
        private static TelevisionChannelProvider instance;

        public static TelevisionChannelProvider Instance
        {
            get
            {
                if (instance == null) 
                {
                    instance = new TelevisionChannelProvider();
                }

                return instance;
            }
        }

        public TelevisionChannelProvider()
        {
            Channels = new LinkedList<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel>();
        }

        public LinkedList<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel> Channels { get; private set; }

        public async System.Threading.Tasks.Task UpdateAsync()
        {
            Channels.Clear();

            var client = new HIPS.Web.API.Connect.Clients.TelevisionChannelAPIConnectClient(HIPSAPIHttpClientHelperProvider.Instance);

            var models = await client.GetAsync();

            Channels = new LinkedList<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel>(models);
        }
    }
}
