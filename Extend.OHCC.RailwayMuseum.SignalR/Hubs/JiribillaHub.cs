using Microsoft.AspNetCore.SignalR;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.SignalR.Hubs
{
    public class JiribillaHub : Hub<Connect.Clients.IJiribillaClient>, Connect.Hubs.IJiribillaHub
    {
        public void StartSession(Connect.Enumerations.JiribillaRole role)
        {
            throw new System.NotImplementedException();
        }

        public void EndSession()
        {
            throw new System.NotImplementedException();
        }
    }
}
