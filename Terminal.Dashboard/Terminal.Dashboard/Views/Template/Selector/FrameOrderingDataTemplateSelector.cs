namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Views.Template.Selector
{
    public class FrameOrderingDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Xamarin.Forms.DataTemplate PositionReferenceFrameDataTemplate { get; set; }

        public Xamarin.Forms.DataTemplate PositionPickFrameDataTemplate { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            var model = item as Support.Presentation.Models.View.FrameViewModel;

            if (model.Placard != null)
            {
                return PositionReferenceFrameDataTemplate;
            }

            return PositionPickFrameDataTemplate;
        }
    }
}
