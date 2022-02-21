namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Views
{
    public partial class InfinityVideoPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Templating.Presentation.Presenters.ScreenplayPresenter screenplayPresenter;

        public InfinityVideoPlacardView(Models.View.InfinityVideoPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var targetTemplateDescriptor = new Essential.Templating.Descriptors.SimpleVideoTemplateDescriptor();

            var targetTemplateViewModel = new Support.Presentation.Models.View.TemplateViewModel
            {
                Id = targetTemplateDescriptor.Id,
                PlayerOrientationSupport = Common.Templating.Enumerations.PlayerOrientationSupportKind.Any
            };

            var placards = new System.Collections.Generic.List<Support.Presentation.Models.View.PlacardViewModel>
            {
                new Support.Presentation.Models.View.PlacardViewModel
                {
                    Id = System.Guid.NewGuid(),
                    Template = targetTemplateViewModel,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Essential.Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = false,
                        Video = (BindingContext as Models.View.InfinityVideoPlacardViewModel).Video
                    })
                }
            };

            screenplayPresenter = new Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards.ToArray(), new Providers.InfinityVideoTransitionProvider(), EndPresentation, true, null);

            screenplayPresenter.BeginPresentation();
        } 

        private Common.Presentation.Views.BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id != Essential.Templating.Descriptors.SimpleVideoTemplateDescriptor.ID) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Essential.Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel>(model.SerializedContext);

            return new StrechAspectFillVideoPlacardView(new Essential.Templating.Presentation.Models.View.SimpleVideoPlacardViewModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(context.Video.Id, context.Video.Extension).AbsoluteUri)
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            screenplayPresenter.Dispose();

            screenplayPresenter = null;
        }
    }
}