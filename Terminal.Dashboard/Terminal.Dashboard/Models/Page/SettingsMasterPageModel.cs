namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class SettingsMasterPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private const string MATERIAL_DESIGN_ICONS_FONTFAMILY = "Material Design Icons";
        private const string VIDERHE_FONT_ICONS_FONTFAMILY = "Viderhe Font Icons";

        public SettingsMasterPageModel()
        {
            Moderator = new View.ModeratorViewModel { Model = Managers.SessionManager.Instance.Moderator };

            Sections = new System.Collections.Generic.List<View.SettingSectionViewModel>
            {
                new View.SettingSectionViewModel(new View.SettingSectionItemViewModel[]
                {
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = VIDERHE_FONT_ICONS_FONTFAMILY,
                        Title = "Viderhe Control 1.0 Prime",
                        Glyph = "B"
                    },
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Actualización",
                        Glyph = "\uf6af"
                    }
                })
                {
                    Title = "Versión"
                },
                new View.SettingSectionViewModel(new View.SettingSectionItemViewModel[]
                {
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Tema",
                        Glyph = "\uf50e"
                    },
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Fondo",
                        Glyph = "\uf8b4"
                    },
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Miniaturas",
                        Glyph = "\uf570"
                    }
                })
                {
                    Title = "Apariencia"
                },
                new View.SettingSectionViewModel(new View.SettingSectionItemViewModel[]
                {
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Canales de contacto",
                        Glyph = "\uf28c"
                    },
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = MATERIAL_DESIGN_ICONS_FONTFAMILY,
                        Title = "Reportar un problema",
                        Glyph = "\uf0e4"
                    }
                })
                {
                    Title = "Soporte"
                },
                new View.SettingSectionViewModel(new View.SettingSectionItemViewModel[]
                {
                    new View.SettingSectionItemViewModel
                    {
                        FontFamily = VIDERHE_FONT_ICONS_FONTFAMILY,
                        Title = "Acerca de Viderhe",
                        Glyph = "A"
                    },
                    new View.SettingSectionItemViewModel
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

        public View.ModeratorViewModel Moderator { get; private set; }

        public System.Collections.Generic.List<View.SettingSectionViewModel> Sections { get; private set; }

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
