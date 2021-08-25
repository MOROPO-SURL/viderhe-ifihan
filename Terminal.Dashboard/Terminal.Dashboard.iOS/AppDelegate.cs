
using Foundation;
using UIKit;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();

            Xamarin.Forms.DependencyService.Register<Plugin.Toasts.ToastNotification>();

            Plugin.Toasts.ToastNotification.Init();

            LoadApplication(new App());

            _ = System.Reflection.Assembly.GetAssembly(typeof(Extend.Essential.Templating.Dashboard.Presentation.Providers.PlacardConfigurationPageProvider));
            _ = System.Reflection.Assembly.GetAssembly(typeof(Extend.Essential.Overlaying.Dashboard.Presentation.Providers.OverlayConfigurationPageProvider));
            _ = System.Reflection.Assembly.GetAssembly(typeof(Extend.Essential.Transitioning.Presentation.Providers.TransitionProvider));

            return base.FinishedLaunching(app, options);
        }
    }
}
