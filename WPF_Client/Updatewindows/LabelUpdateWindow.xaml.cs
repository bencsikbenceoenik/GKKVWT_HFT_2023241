using GKKVWT_HFT_2023241.Models;
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
using System.Windows.Shapes;
using Label = GKKVWT_HFT_2023241.Models.Label;

namespace WPF_Client.Updatewindows
{
    /// <summary>
    /// Interaction logic for LabelUpdateWindow.xaml
    /// </summary>
    public partial class LabelUpdateWindow : Window
    {
        public Label SelectedLabel { get; private set; }
        public LabelUpdateWindow(Label selectedLabel)
        {
            InitializeComponent();
            SelectedLabel = selectedLabel;
            DataContext = SelectedLabel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
