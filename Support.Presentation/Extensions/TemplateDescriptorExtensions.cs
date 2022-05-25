using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Descriptors;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions
{
    public static class TemplateDescriptorExtensions
    {
        public static Models.View.TemplateViewModel ToViewModel<TTemplateDescriptor>(this TTemplateDescriptor templateDescriptor)
            where TTemplateDescriptor : class, ITemplateDescriptor
        {
            if (templateDescriptor == null) return null;

            var resourceId = string.Format("{0}.Assets.{1}{2}.png", templateDescriptor.GetType().AssemblyQualifiedName.Split(',')[1].Trim(), templateDescriptor.Id.ToString().ToUpper(), templateDescriptor.PlayerOrientationSupport.ToImageResourceNameSufix());

            var model = new Models.View.TemplateViewModel
            {
                Id = templateDescriptor.Id,
                Name = templateDescriptor.Name,
                About = templateDescriptor.Description,
                PlayerOrientationSupport = templateDescriptor.PlayerOrientationSupport,
                ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource(resourceId, templateDescriptor.GetType().Assembly)
            };

            return model;
        }
    }
}