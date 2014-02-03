using System;
using System.Windows;

namespace GermanVocabulary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            
            try
            {
                Exception ex = e.Exception;
                string errorMsg = "Sorry for the inconvenience. The Application is going to close.";
                MessageBox.Show(errorMsg);
                e.Handled = true;
                Application.Current.Shutdown();  
            }
            catch { MessageBox.Show("Sorry for the inconvenience."); }
        }
    }
}
