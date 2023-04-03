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

namespace FlowModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculations calculations;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer.Content = "";

            if (Temperature == null) return;

            if(Width.Text == "" || Height.Text == "" || Length.Text == "")
            {
                double temperature = Convert.ToDouble(Temperature.Text.ToString());
                calculations = new Calculations(temperature);
            }
            else
            {
                double temperature = Convert.ToDouble(Temperature.Text.ToString());
                double width = Convert.ToDouble(Width.Text.ToString());
                double height = Convert.ToDouble(Height.Text.ToString());
                double length = Convert.ToDouble(Length.Text.ToString());
                calculations = new Calculations(temperature, width, height, length);
            }

            Answer.Content = Math.Round(calculations.CoefficientOfConsistensy(), 5).ToString();
            
        }
    }
}
