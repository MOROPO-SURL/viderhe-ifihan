using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Sections;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Providers
{
    public class ManageSectionPageProvider : Common.Management.Dashboard.Presentation.Providers.Facade.IManageSectionPageProviderFacade
    {
        public Xamarin.Forms.Page GetManagementPageBySection(Common.Management.Sections.Contract.IManagementSection section)
        {
            if (section is HotelOTTManagementSection)
            {
                return new Pages.MainPage();
            }

            return null;
        }
    }
}
