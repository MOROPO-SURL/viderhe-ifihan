namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Views.Template.Selector
{
    public class ActionDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Xamarin.Forms.DataTemplate SimpleActionDataTemplate { get; set; }

        public Xamarin.Forms.DataTemplate SessionActionDataTemplate { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            var action = item as Models.View.ActionViewModel;

            if (action is Models.View.SessionActionViewModel)
            {
                return SessionActionDataTemplate;
            }

            return SimpleActionDataTemplate;
        }
    }
}
