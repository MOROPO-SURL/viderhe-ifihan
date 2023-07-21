using MOROPO.SAPRESSC.Core.Persistence.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class Account : IHabilitableEntity<System.Guid>, IPersistenceSignable
    {
        [Key]
        public System.Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PrimaryColor { get; set; }

        [Required]
        public string SecoundaryColor { get; set; }

        public int MaxPlayerCount { get; set; }

        public System.Guid LogoId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("LogoId")]
        public MOROPO.SAPRESSC.Middleware.Media.Persistence.Entities.Image Logo { get; set; }

        public System.Guid HorizontalSplashId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("HorizontalSplashId")]
        public MOROPO.SAPRESSC.Middleware.Media.Persistence.Entities.Image HorizontalSplash { get; set; }

        public System.Guid VerticalSplashId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("VerticalSplashId")]
        public MOROPO.SAPRESSC.Middleware.Media.Persistence.Entities.Image VerticalSplash { get; set; }

        public System.Guid? DefaultOverlayId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("DefaultOverlayId")]
        public Overlay DefaultOverlay { get; set; }

        public string SerializedOverlayContext { get; set; }

        public System.DateTime CreateAt { get; set; }

        public List<Player> Players { get; set; }

        public List<Screenplay> Screenplays { get; set; }

        public List<Placard> Placards { get; set; }

        public List<AccountModeratorBridge> ModeratorBridges { get; set; }

        public List<AccountImageBridge> ImageBridges { get; set; }

        public List<AccountVideoBridge> VideoBridges { get; set; }

        public List<AccountExtensionBridge> ExtensionBridges { get; set; }

        public List<AccountSoundBridge> SoundBridges { get; set; }

        public List<AccountGradientBridge> GradientBridges { get; set; }

        public List<AccountTextBridge> TextBridges { get; set; }

        public bool Enabled { get; set; }

        [Required]
        public string Signature { get; set; }

        public Account()
        {
            Id = System.Guid.NewGuid();

            CreateAt = System.DateTime.Now;

            Players = new List<Player>();
            Screenplays = new List<Screenplay>();
            Placards = new List<Placard>();

            ModeratorBridges = new List<AccountModeratorBridge>();
            ImageBridges = new List<AccountImageBridge>();
            VideoBridges = new List<AccountVideoBridge>();
            ExtensionBridges = new List<AccountExtensionBridge>();
            SoundBridges = new List<AccountSoundBridge>();
            GradientBridges = new List<AccountGradientBridge>();
            TextBridges = new List<AccountTextBridge>();
        }

        public object GetSignableEntityModel()
        {
            return new { Id, Name, Enabled, MaxPlayerCount, PrimaryColor, SecoundaryColor };
        }
    }
}
