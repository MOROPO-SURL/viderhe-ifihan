namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.SignalR.Connect.Clients
{
    public interface IJiribillaClient
    {
        void StartSession(string host, string[] guests, string expecterProjector);

        void EndSession();
    }
}
