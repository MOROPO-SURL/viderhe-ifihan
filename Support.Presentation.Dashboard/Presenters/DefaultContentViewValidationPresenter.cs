using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters
{
    public class DefaultContentViewValidationPresenter : IFormFieldValidationPresenter
    {
        private static DefaultContentViewValidationPresenter instance;

        public static DefaultContentViewValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultContentViewValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            view.BackgroundColor = Xamarin.Forms.Color.Tomato;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            view.BackgroundColor = Xamarin.Forms.Color.Black;
        }
    }
}
