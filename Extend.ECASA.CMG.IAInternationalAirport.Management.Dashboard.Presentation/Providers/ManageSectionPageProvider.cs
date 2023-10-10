namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Providers
{
    public class ManageSectionPageProvider : Common.Management.Dashboard.Presentation.Providers.Facade.IManageSectionPageProviderFacade
    {
        public Xamarin.Forms.Page GetManagementPageBySection(Common.Management.Sections.Contract.IManagementSection section)
        {
            if (section is Sections.InteropAirportDISMangementSection)
            {
                return new Pages.MainPage();
            }

            return null;
        }
    }
}
