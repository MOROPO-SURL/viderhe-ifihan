using SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class PictureSecuencePlacardView : BasePlacardPresentationView, Common.Motion.Presentation.Providers.Facade.IMotionTransitionProviderFacade
    {
        private Models.Context.PictureSecuencePlacardContextModel context;
        private Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider;
        private Common.Motion.Presentation.Providers.Facade.IMotionTransitionProviderFacade motionTransitionProvider;
        private Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider;

        private Common.Templating.Presentation.Presenters.ScreenplayPresenter screenplayPresenter;

        private System.Guid motionTransitionId;

        public PictureSecuencePlacardView(Models.Context.PictureSecuencePlacardContextModel context, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Common.Motion.Presentation.Providers.Facade.IMotionTransitionProviderFacade motionTransitionProvider)
        {
            InitializeComponent();

            this.context = context;

            this.cloudServerProvider = cloudServerProvider;
            this.motionTransitionProvider = motionTransitionProvider;
            this.accountInformationProvider = accountInformationProvider;

            motionTransitionId = context.PictureTransitionId;

            BindingContext = new Models.View.PictureSecuencePlacardViewModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
            };
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => FramesContainerWrapper;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void ShowInTransitionCompleteCallback()
        {
            base.ShowInTransitionCompleteCallback();

            var placards = new System.Collections.Generic.List<Support.Presentation.Models.View.PlacardViewModel>();

            var targetTemplateDescriptor = new Descriptors.SimplePictureTemplateDescriptor();

            var targetTemplateViewModel = new Support.Presentation.Models.View.TemplateViewModel
            {
                Id = targetTemplateDescriptor.Id
            };

            foreach (var item in context.Images)
            {
                placards.Add(new Support.Presentation.Models.View.PlacardViewModel
                {
                    Id = System.Guid.NewGuid(),
                    Template = targetTemplateViewModel,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Models.Context.SimplePicturePlacardContextModel
                    {
                        Image = item,
                        Aspect = Xamarin.Forms.Aspect.AspectFill,
                        ScreenPresentationTime = System.TimeSpan.FromSeconds(context.PicturePresentationSecounds),
                        ZoomingEnabled = true
                    })
                });
            }

            screenplayPresenter = new Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards.ToArray(), accountInformationProvider, this, EndPresentation, false, null);

            screenplayPresenter.BeginPresentation();
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id != Descriptors.SimplePictureTemplateDescriptor.ID) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.SimplePicturePlacardContextModel>(model.SerializedContext);

            return new SimplePicturePlacardView(new Models.View.SimplePicturePlacardViewModel
            {
                Source = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(cloudServerProvider, context.Image.Id)),
                Aspect = context.Aspect,
                ScreenPresentationTime = context.ScreenPresentationTime,
                ZoomingEnabled = context.ZoomingEnabled
            });
        }

        public Common.Motion.Presentation.Transitions.AbstractTransition GetFor(System.Guid transitionDescriptorId, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return motionTransitionProvider.GetFor(motionTransitionId, accountInformationProvider, incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
        }

        public Common.Motion.Presentation.Transitions.AbstractTransition GetRandom(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return motionTransitionProvider.GetFor(motionTransitionId, accountInformationProvider, incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            context = null;
            cloudServerProvider = null;
            motionTransitionProvider = null;
            accountInformationProvider = null;

            screenplayPresenter.Dispose();

            screenplayPresenter = null;
        }
    }
}