namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Persistence.Entities;

public partial class Arraival
{
    public int KeyCol { get; set; }

    public int? Idoper { get; set; }

    public int? Estado { get; set; }

    public string Vuelo { get; set; }

    public string OrigDest { get; set; }

    public string Puerta { get; set; }

    public int? Categoria { get; set; }

    public bool? Mostrar { get; set; }

    public System.DateTime? DateTimeP { get; set; }

    public System.DateTime? DateTimeR { get; set; }

    public string Compania { get; set; }

    public string NumeroVuelo { get; set; }

    public string Terminal { get; set; }

    public string AD { get; set; }
}
