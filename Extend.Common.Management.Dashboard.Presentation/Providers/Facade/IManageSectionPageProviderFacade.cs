using SmartSolucionesCuba.Viderhe.Extend.Common.Management.Sections.Contract;

namespace SmartSolucionesCuba.Viderhe.Extend.Common.Management.Dashboard.Presentation.Providers.Facade
{
    public interface IManageSectionPageProviderFacade
    {
        Xamarin.Forms.Page GetManagementPageBySection(IManagementSection section);
    }
}
