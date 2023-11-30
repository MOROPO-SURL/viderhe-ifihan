using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ConfigureGradientPageModel : FormPageModel
    {
        private MagicGradients.CssGradientSource source;
        private string about;
        private string data;

        public System.Guid Id { get; set; }

        public MagicGradients.CssGradientSource Source
        {
            get => source;
            set => SetProperty(ref source, value);
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public string Data { get => data; set => SetProperty(ref data, value, DataChanged_Callback); }

        private void DataChanged_Callback()
        {
            try
            {
                Source = MagicGradients.CssGradientSource.Parse(Data);
            }
            catch
            {
                Source = null;
            }
        }
    }
}
