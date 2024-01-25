using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.SignalR.Connect.Common.Enumerations;

namespace MOROPO.VIDERHE.Cloud.SignalR.Connect.Player.Clients
{
    public interface IPlayerClient
    {
        System.Threading.Tasks.Task OnPresentNextFrameRequestAsync();
        System.Threading.Tasks.Task OnPresentPreviousFrameRequestAsync();
        System.Threading.Tasks.Task OnPresentInterventionPlacardsRequestAsync(PlacardDisplayModel[] placards);
        System.Threading.Tasks.Task OnRestartScreenplayRequestAsync(ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task OnReloadScreenplayRequestAsync(ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task OnSetAudioLevelRequestAsync(int percent);
        System.Threading.Tasks.Task OnSetAudioEnabledRequestAsync(bool enabled);
        System.Threading.Tasks.Task OnCloseRequestAsync(bool restart);
        System.Threading.Tasks.Task OnShutdownRequestAsync(bool restart);
    }
}
