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
using System.Management;

namespace NetworkPrinterSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetPrinters_Click(object sender, RoutedEventArgs e)
        {
            // Use the ObjectQuery to get the list of configured printers
            System.Management.ObjectQuery oquery = new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");

            System.Management.ManagementObjectSearcher mosearcher =
                new System.Management.ManagementObjectSearcher(oquery);

            System.Management.ManagementObjectCollection moc = mosearcher.Get();

            foreach (ManagementObject mo in moc)
            {
                System.Management.PropertyDataCollection pdc = mo.Properties;
                foreach (System.Management.PropertyData pd in pdc)
                {
                    if ((bool)mo["Network"])
                    {
                        cmbPrinters.Items.Add(mo[pd.Name]);
                    }
                }
            }
        }
    }
}
