using MOROPO.VIDERHE.Terminal.Dashboard.Enumerations;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Delegates
{
    public delegate void TouchActionEventHandler(object sender, TouchActionEventArgs args);

    public class TouchActionEventArgs : System.EventArgs
    {
        public TouchActionEventArgs(long id, TouchActionKind kind, Xamarin.Forms.Point location, bool isInContact)
        {
            Id = id;
            Kind = kind;
            Location = location;
            IsInContact = isInContact;
        }

        public long Id { private set; get; }

        public TouchActionKind Kind { private set; get; }

        public Xamarin.Forms.Point Location { private set; get; }

        public bool IsInContact { private set; get; }
    }
}
