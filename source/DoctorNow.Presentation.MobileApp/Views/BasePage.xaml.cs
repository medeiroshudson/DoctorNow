using DoctorNow.Presentation.MobileApp.Helpers;

namespace DoctorNow.Presentation.MobileApp.Views;

public abstract partial class BasePage : ContentPage
{
    public abstract void Build();

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Build();

#if DEBUG
        HotReload.UpdateApplicationEvent += ReloadInterface;
#endif
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);

#if DEBUG
        HotReload.UpdateApplicationEvent -= ReloadInterface;
#endif
    }

    private void ReloadInterface(Type[]? obj)
        => MainThread.BeginInvokeOnMainThread(Build);
}