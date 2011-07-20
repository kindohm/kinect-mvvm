using System.Windows;

namespace KinectMvvm
{
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            ViewModelLoader.Cleanup();
            base.OnExit(e);
        }
    }
}
