namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.View
{
    public class SettingSectionViewModel : System.Collections.Generic.List<SettingSectionItemViewModel>, System.IDisposable
    {
        public SettingSectionViewModel(SettingSectionItemViewModel[] items) : base(items)
        {
        }

        public string Title { get; set; }

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

                foreach (var item in this)
                {
                    item.Dispose();
                }

                this.Clear();

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
