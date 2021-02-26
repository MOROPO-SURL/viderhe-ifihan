using SkiaSharp.Views.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Views
{
    public partial class TourOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        private const int CYCLE_TIME_MILLISECOUNDS = 1000;

        private static System.TimeSpan TIMER_TIME = System.TimeSpan.FromMilliseconds(33);

        private readonly SkiaSharp.SKColor animationWavePropagationColor;

        private float animationWavePropagationRefPoint;

        private System.TimeSpan receiverPrecenceExpirationRefPoint;

        private System.Diagnostics.Stopwatch stopwatch;

        private System.Threading.CancellationTokenSource defaultCancellationTokenSource;

        public TourOverlayView(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            InitializeComponent();

            receiverPrecenceExpirationRefPoint = System.TimeSpan.Zero;

            animationWavePropagationColor = accountInformationProvider.PrimaryColor.WithLuminosity(0.85).ToSKColor();

            stopwatch = new System.Diagnostics.Stopwatch();

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(3)).ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentForIndleState);
            });
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            args.Surface.Canvas.Clear();

            if (!IsEnabled) return;

            var animationWavePropagationColor = Xamarin.Forms.Color.IndianRed.WithLuminosity(0.85).ToSKColor();

            var center = new SkiaSharp.SKPoint(args.Info.Width / 2, args.Info.Height / 2);

            float baseRadius = System.Math.Min(args.Info.Width, args.Info.Height) / 12;

            var colorRed = animationWavePropagationColor.Red;
            var colorGreen = animationWavePropagationColor.Green;
            var colorBlue = animationWavePropagationColor.Blue;

            for (int circle = 0; circle < 5; circle++)
            {
                float radius = baseRadius * (circle + animationWavePropagationRefPoint);

                var paint = new SkiaSharp.SKPaint
                {
                    Style = SkiaSharp.SKPaintStyle.Fill
                };

                paint.StrokeWidth = baseRadius / 2 * (circle == 0 ? animationWavePropagationRefPoint : 1);

                paint.Color = new SkiaSharp.SKColor(colorRed, colorGreen, colorBlue, (byte)(255 * (1 - animationWavePropagationRefPoint)));

                args.Surface.Canvas.DrawCircle(center.X, center.Y, radius, paint);
            }
        }

        private void PresentForTourStartOptionState()
        {
            stopwatch.Start();

            IsEnabled = true;

            Xamarin.Forms.Device.StartTimer(TIMER_TIME, () =>
            {
                animationWavePropagationRefPoint = (float)(stopwatch.Elapsed.TotalMilliseconds % CYCLE_TIME_MILLISECOUNDS / CYCLE_TIME_MILLISECOUNDS);

                //CanvasView.InvalidateSurface();

                var @continue = IsEnabled && stopwatch.Elapsed < System.TimeSpan.FromSeconds(10);

                if (!@continue)
                {
                    stopwatch.Stop();

                    stopwatch.Reset();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentForIndleState);
                }

                return @continue;
            });
        }

        private void PresentForIndleState()
        {
            IsEnabled = false;

            //CanvasView.InvalidateSurface();

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(3)).ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentForTourStartOptionState);
            });
        }
    }
}