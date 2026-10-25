using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Views
{
    public partial class PortraitPlacardThumbnailWrapView : Xamarin.Forms.ContentView
    {
        public PortraitPlacardThumbnailWrapView(PlacardViewModel model)
        {
            InitializeComponent();

            var templateDescriptor = Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(model.Template.Id);

            var resourceId = string.Format("{0}.Assets.{1}{2}.png", templateDescriptor.GetType().AssemblyQualifiedName.Split(',')[1].Trim(), templateDescriptor.Id.ToString().ToUpper(), PlayerOrientationSupportKind.Portrait.ToImageResourceNameSufix());

            BindingContext = new PlacardViewModel
            {
                Id = model.Id,
                Label = model.Label,
                BeginAt = model.BeginAt,
                EndAt = model.EndAt,
                PlayerOrientationSupportKind = model.PlayerOrientationSupportKind,
                SerializedContext = model.SerializedContext,
                ComplementationKind = model.ComplementationKind,
                SerializedComplementation = model.SerializedComplementation,
                Tags = model.Tags,
                Template = new TemplateViewModel
                {
                    Id = templateDescriptor.Id,
                    Name = templateDescriptor.Name,
                    About = templateDescriptor.Description,
                    PlayerOrientationSupport = templateDescriptor.PlayerOrientationSupport,
                    ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource(resourceId, templateDescriptor.GetType().Assembly)
                }
            };
        }
    }
}