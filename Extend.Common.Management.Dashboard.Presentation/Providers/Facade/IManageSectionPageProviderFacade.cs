using MOROPO.VIDERHE.Extend.Common.Management.Sections.Contract;

namespace MOROPO.VIDERHE.Extend.Common.Management.Dashboard.Presentation.Providers.Facade
{
    public interface IManageSectionPageProviderFacade
    {
        Xamarin.Forms.Page GetManagementPageBySection(IManagementSection section);
    }
}
