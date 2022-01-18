namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.SignalR.Extensions
{
    public static class HubRouteBuilderExtensions
    {
        public static void PerformHubsRegistration(this Microsoft.AspNetCore.SignalR.HubRouteBuilder target)
        {
            target.MapHub<Hubs.JiribillaHub>("/hubs/ohcc/railwaymuseum/jiribilla");
        }
    }
}
