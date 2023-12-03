using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Views.Template.Selector
{
    public class ActionDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Xamarin.Forms.DataTemplate SimpleActionDataTemplate { get; set; }

        public Xamarin.Forms.DataTemplate SessionActionDataTemplate { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            var action = item as ActionViewModel;

            if (action is SessionActionViewModel)
            {
                return SessionActionDataTemplate;
            }

            return SimpleActionDataTemplate;
        }
    }
}
