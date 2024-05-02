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

namespace WPF_Client.Updatewindows
{
    /// <summary>
    /// Interaction logic for SongUpdateWindow.xaml
    /// </summary>
    public partial class SongUpdateWindow : Window
    {
        public Song SelectedSong { get; set; }
        public SongUpdateWindow(Song selectedsong)
        {
            SelectedSong = selectedsong;
            DataContext = SelectedSong;
            InitializeComponent();
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
