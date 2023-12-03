using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPlacardConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private bool requireUnobstructedPresetation;
        private ConfigurationPlayerOrientationSupportKind playerOrientationSupportKind;
        private System.DateTime beginAt;
        private System.DateTime endAt;
        private bool defineBeginAt;
        private bool defineEndAt;

        public AbstractPlacardConfigurationPageModel()
        {
            AvailableConfigurationPlayerOrientationSupportKinds = new[] { ConfigurationPlayerOrientationSupportKind.Inherited, ConfigurationPlayerOrientationSupportKind.Landscape, ConfigurationPlayerOrientationSupportKind.Portrait };
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public bool RequireUnobstructedPresetation { get => requireUnobstructedPresetation; set => SetProperty(ref requireUnobstructedPresetation, value); }

        public bool DefineBeginAt { get => defineBeginAt; set => SetProperty(ref defineBeginAt, value); }

        public System.DateTime BeginAt { get => beginAt; set => SetProperty(ref beginAt, value); }

        public bool DefineEndAt { get => defineEndAt; set => SetProperty(ref defineEndAt, value); }

        public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }

        public ConfigurationPlayerOrientationSupportKind PlayerOrientationSupportKind { get => playerOrientationSupportKind; set => SetProperty(ref playerOrientationSupportKind, value); }

        public ConfigurationPlayerOrientationSupportKind[] AvailableConfigurationPlayerOrientationSupportKinds { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }
    }
}
