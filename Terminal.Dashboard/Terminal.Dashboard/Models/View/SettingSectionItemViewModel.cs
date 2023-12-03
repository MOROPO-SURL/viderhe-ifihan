namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.View
{
    public class SettingSectionItemViewModel : System.IDisposable
    {
        public string Glyph { get; set; }

        public string FontFamily { get; set; }

        public string Title { get; set; }

        public System.Func<Xamarin.Forms.Page> ActivateFunc { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                ActivateFunc = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
