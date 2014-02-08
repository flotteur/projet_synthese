using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ServiceModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPF_ClientSynthèse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceWCF_Synthese.ServiceWCF_SyntheseClient Proxy { get; set; }



        public MainWindow() {
            InitializeComponent();

            Uri baseAddress = new Uri("http://http://localhost:2037");
            string adresse = "http://localhost:2037/ServiceWCF_Synthese.svc";

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress epAdresse = new EndpointAddress(adresse);

            this.Proxy = new ServiceWCF_Synthese.ServiceWCF_SyntheseClient();

        }

        private void btnGo_Click(object sender, RoutedEventArgs e) {
            ServiceWCF_Synthese.UsagerWCF usager = Proxy.GetUsager(1);
        }
    }
}
