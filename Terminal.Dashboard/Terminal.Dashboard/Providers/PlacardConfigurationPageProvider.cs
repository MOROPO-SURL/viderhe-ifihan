using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Providers
{
    public sealed class PlacardConfigurationPageProvider
    {
        private static PlacardConfigurationPageProvider instance;

        public static PlacardConfigurationPageProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardConfigurationPageProvider();
                }

                return instance;
            }
        }

        private PlacardConfigurationPageProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Viderhe.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Dashboard.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Extend.Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Extend.Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetCreationEntryPointPageByDescriptor(templateDescriptor, Presenters.NotificationPresenter.Instance, Managers.SessionManager.Instance, (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade), completedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetEditionPageByDescriptor(placardViewModel, CloudServerProvider.Instance, Presenters.NotificationPresenter.Instance, Managers.SessionManager.Instance, (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade), completedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
