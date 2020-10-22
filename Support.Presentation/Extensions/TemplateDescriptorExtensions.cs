using SmartSolucionesCuba.Videre.Extend.Common.Templating.Descriptors;

namespace SmartSolucionesCuba.Videre.Support.Presentation.Extensions
{
    public static class TemplateDescriptorExtensions
    {
        public static Models.View.TemplateViewModel ToViewModel<TTemplateDescriptor>(this TTemplateDescriptor templateDescriptor)
            where TTemplateDescriptor : class, ITemplateDescriptor
        {
            var resourceId = string.Format("{0}.{1}.png", templateDescriptor.GetType().AssemblyQualifiedName.Split(',')[1].Trim(), templateDescriptor.Id.ToString().ToUpper());

            var model = new Models.View.TemplateViewModel
            {
                Id = templateDescriptor.Id,
                Name = templateDescriptor.Name,
                About = templateDescriptor.Description,
                ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource(resourceId, templateDescriptor.GetType().Assembly)
            };

            return model;
        }
    }
}
