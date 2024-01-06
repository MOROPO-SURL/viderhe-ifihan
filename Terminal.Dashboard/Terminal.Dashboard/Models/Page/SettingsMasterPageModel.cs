using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class SettingsMasterPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private const string MATERIAL_DESIGN_ICONS_FONTFAMILY = "Material Design Icons";
        private const string VIDERHE_FONT_ICONS_FONTFAMILY = "Viderhe Font Icons";

        public SettingsMasterPageModel()
        {
            Moderator = new ModeratorViewModel { Model = SessionManager.Instance.Moderator };

            Sections = new System.Collections.Generic.List<SettingSectionViewModel>
            {
                new SettingSectionViewModel(new SettingSectionItemViewModel[]
                {
                    new SettingSectionItemViewModel
                    {
                        FontFamily = VIDERHE_FONT_ICONS_FONTFAMILY,
                        Title = "Viderhe Control 1.0 Prime",
                        Glyph = "B"
                    },
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Actualización",
                        Glyph = "\uf6af"
                    }
                })
                {
                    Title = "Versión"
                },
                new SettingSectionViewModel(new SettingSectionItemViewModel[]
                {
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Tema",
                        Glyph = "\uf50e"
                    },
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Fondo",
                        Glyph = "\uf8b4"
                    },
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Miniaturas",
                        Glyph = "\uf570"
                    }
                })
                {
                    Title = "Apariencia"
                },
                new SettingSectionViewModel(new SettingSectionItemViewModel[]
                {
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Canales de contacto",
                        Glyph = "\uf28c"
                    },
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Reportar un problema",
                        Glyph = "\uf0e4"
                    }
                })
                {
                    Title = "Soporte"
                },
                new SettingSectionViewModel(new SettingSectionItemViewModel[]
                {
                    new SettingSectionItemViewModel
                    {
                        FontFamily = VIDERHE_FONT_ICONS_FONTFAMILY,
                        Title = "Acerca de Viderhe",
                        Glyph = "A"
                    },
                    new SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "SMART SOLUCIONES CUBA",
                        Glyph = "\uf990"
                    }
                })
                {
                    Title = "Información"
                }
            };
        }

        public ModeratorViewModel Moderator { get; private set; }

        public System.Collections.Generic.List<SettingSectionViewModel> Sections { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Moderator = null;

            foreach (var item in Sections)
            {
                item.Dispose();
            }

            Sections.Clear();

            Sections = null;
        }
    }
}
