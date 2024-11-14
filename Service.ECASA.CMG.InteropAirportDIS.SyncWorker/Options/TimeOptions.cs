namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Options
{
    public class TimeOptions
    {
        public System.TimeSpan IterationElapseTime { get; set; }

        public System.TimeSpan PreCheckInTime { get; set; } = System.TimeSpan.Zero;

        public System.TimeSpan PostCheckInTime { get; set; } = System.TimeSpan.Zero;
    }
}
