using Microsoft.UI.Xaml;

namespace WinUI.Samples.LoginPages.SpaceGuard;

public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
    }
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new StartupWindow();
        m_window.Activate();
    }

    private Window m_window;
}
