namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.SignalR.Connect.Hubs
{
    public interface IJiribillaHub
    {
        void StartSession(Enumerations.JiribillaRole role);

        void EndSession();
    }
}
