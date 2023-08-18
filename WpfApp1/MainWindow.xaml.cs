using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AppServiceConnection connection = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAppServiceConnection();
        }

        /// <summary>
        /// Open connection to UWP app service
        /// </summary>
        private async void InitializeAppServiceConnection()
        {
            connection = new AppServiceConnection();
            connection.AppServiceName = "SampleInteropService";
            connection.PackageFamilyName = Package.Current.Id.FamilyName;
            //connection.RequestReceived += Connection_RequestReceived;
            connection.ServiceClosed += Connection_ServiceClosed;

            AppServiceConnectionStatus status = await connection.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                // something went wrong ...
                MessageBox.Show(status.ToString());
                this.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the event when the app service connection is closed
        /// </summary>
        private void Connection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            // connection to the UWP lost, so we shut down the desktop process
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                Application.Current.Shutdown();
            }));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // ask the UWP to calculate d1 + d2
            ValueSet request = new ValueSet();
            request.Add("D1", (double)1);
            request.Add("D2", (double)2);
            AppServiceResponse response = await connection.SendMessageAsync(request);
            double result = (double)response.Message["RESULT"];
            tbResult.Content = result.ToString();
        }
    }

    
}
