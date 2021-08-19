namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Tizen.TV
{
    public class Program : Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            MainWindow.BackgroundColor = ElmSharp.Color.Black;
            MainWindow.NoBlank = true;

            Xamarin.Essentials.Platform.Init(MainWindow);

            ElmSharp.Utility.AppendGlobalFontPath(DirectoryInfo.Resource);

            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(app);

            var option = new Xamarin.Forms.InitializationOptions(app) 
            { 
                UseSkiaSharp = true,
                UseDeviceIndependentPixel = true
            };

            Xamarin.Forms.Forms.Init(option);

            app.Run(args);
        }
    }
}
