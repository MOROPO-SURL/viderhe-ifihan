namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views
{
    public partial class ClassicDeparturesPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Facade.IInteroperablePlacardFacade
    {
        public ClassicDeparturesPlacardView(Models.View.ClassicDeparturesPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => DeparturesLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var model = BindingContext as Models.View.ClassicDeparturesPlacardViewModel;

            model.Items = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel>();

            System.Threading.Tasks.Task.Run(() =>
            {
                for (int i = 1; i <= 6; i++)
                {
                    System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1));

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        model.Items.Add(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel
                        {
                            Id = i,
                            Flight = i * 111,
                            StartDate = System.DateTime.Now,
                            Status = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.StatusDisplayModel
                            {
                                Label = "Demorado",
                                EmphasisBackgroundColor = Xamarin.Forms.Color.AliceBlue.ToHex(),
                                EmphasisTextColor = Xamarin.Forms.Color.Black.ToHex(),
                            },
                            Context = "Merida MEXICO",
                            Category = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.CategoryDisplayModel
                            {
                                Name = "Internacional"
                            },
                            Kind = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.KindDisplayModel
                            {
                                Id = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                            },
                            Terminal = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.TerminalDisplayModel
                            {
                                Name = "Internacional 3"
                            },
                            Carrier = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.CarrierDisplayModel
                            {
                                Id = "VIV",
                                Name = "Viva Aerobus",
                                PrimaryColor = "#00FF00",
                                SecoundaryColor = "#FF0000",
                                Country = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.CountryDisplayModel
                                {
                                    IsoCode = "mx",
                                    Name = "México"
                                },
                                Image = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel
                                {
                                    Id = System.Guid.Parse("bfd93be0-8c20-4f70-a810-b3c45530d3bc"),
                                    Extension = ".jpg"
                                }
                            }
                        });
                    });
                }
            });
        }

        #region IInteroperablePlacardFacade implementation

        public Models.View.Contract.AbstractInteroperablePlacardViewModel GetInteroperableModel()
        {
            return BindingContext as Models.View.Contract.AbstractInteroperablePlacardViewModel;
        }

        #endregion
    }
}