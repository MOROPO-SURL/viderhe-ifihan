namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Persistence.Entities;

public partial class CheckIn
{
    public short? IdMostrador { get; set; }

    public bool? Vip { get; set; }

    public bool? Habilitado { get; set; }

    public string IdOper { get; set; }

    public System.DateTime? FechaIni { get; set; }

    public System.DateTime? FechaFin { get; set; }

    public bool? Abierto { get; set; }
}
