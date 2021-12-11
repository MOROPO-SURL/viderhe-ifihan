using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Helpers
{
    public static class BorderEffectPresentationHelper
    {
        public static readonly BindableProperty HasBorderEffectProperty = BindableProperty.CreateAttached(
            "HasBorderEffect",
            typeof(bool),
            typeof(BorderEffectPresentationHelper),
            false,
            propertyChanged: OnHasBorderEffectChanged
        );

        public static readonly BindableProperty BorderColorProperty = BindableProperty.CreateAttached(
            "BorderColor",
            typeof(Color),
            typeof(BorderEffectPresentationHelper),
            Color.Default
        );

        public static bool GetHasBorderEffect(BindableObject view)
        {
            return (bool)view.GetValue(HasBorderEffectProperty);
        }

        public static void SetHasBorderEffect(BindableObject view, bool value)
        {
            view.SetValue(HasBorderEffectProperty, value);
        }

        public static Color GetBorderColor(BindableObject view)
        {
            return (Color)view.GetValue(BorderColorProperty);
        }

        public static void SetBorderColor(BindableObject view, Color value)
        {
            view.SetValue(BorderColorProperty, value);
        }

        public static void OnHasBorderEffectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            
            if ((bool)newValue)
            {
                view.Effects.Add(new ViewBorderColorEffect());
            }
            else
            {
                for (int i = 0; i < view.Effects.Count; i++)
                {
                    if (view.Effects[i] is ViewBorderColorEffect)
                    {
                        view.Effects.RemoveAt(i);

                        break;
                    }
                }
            }
        }

        private class ViewBorderColorEffect : RoutingEffect
        {
            public ViewBorderColorEffect() : base("SupportPresentationDashboard.BorderColorEffect") { }
        }
    }
}
