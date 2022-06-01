namespace SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Player.Clients
{
    public interface IPlayerClient
    {
        System.Threading.Tasks.Task OnPresentNextFrameRequestAsync();
        System.Threading.Tasks.Task OnPresentPreviousFrameRequestAsync();
        System.Threading.Tasks.Task OnPresentInterventionPlacardsRequestAsync(Api.Common.Models.PlacardDisplayModel[] placards);
        System.Threading.Tasks.Task OnRestartScreenplayRequestAsync(Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task OnReloadScreenplayRequestAsync(Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task OnSetAudioLevelRequestAsync(int percent);
        System.Threading.Tasks.Task OnSetAudioEnabledRequestAsync(bool enabled);
        System.Threading.Tasks.Task OnCloseRequestAsync(bool restart);
        System.Threading.Tasks.Task OnShutdownRequestAsync(bool restart);
    }
}
