using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Sections;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Providers
{
    public class ManageSectionPageProvider : Common.Management.Dashboard.Presentation.Providers.Facade.IManageSectionPageProviderFacade
    {
        public Xamarin.Forms.Page GetManagementPageBySection(Common.Management.Sections.Contract.IManagementSection section)
        {
            if (section is InteropAirportDISMangementSection)
            {
                return new Pages.MainPage();
            }

            return null;
        }
    }
}
