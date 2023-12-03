namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View
{
    public class GradientViewModel : System.IDisposable
    {
        private bool disposedValue;

        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public MagicGradients.CssGradientSource Source { get; set; }

        public string About { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                Source = null;

                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~GradientViewModel()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
