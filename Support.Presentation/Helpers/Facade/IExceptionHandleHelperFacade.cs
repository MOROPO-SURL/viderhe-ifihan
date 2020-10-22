namespace SmartSolucionesCuba.Videre.Support.Presentation.Helpers.Facade
{
    public interface IExceptionHandleHelperFacade
    {
        void HandleException(System.Exception exception, System.Action continuationCallback = null);
    }
}
