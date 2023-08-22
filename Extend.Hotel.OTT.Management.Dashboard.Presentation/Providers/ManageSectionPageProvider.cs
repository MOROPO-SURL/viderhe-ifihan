namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Providers
{
    public class ManageSectionPageProvider : Common.Management.Dashboard.Presentation.Providers.Facade.IManageSectionPageProviderFacade
    {
        public Xamarin.Forms.Page GetManagementPageBySection(Common.Management.Sections.Contract.IManagementSection section)
        {
            if (section is Sections.HotelOTTManagementSection)
            {
                return new Pages.MainPage();
            }

            return null;
        }
    }
}
