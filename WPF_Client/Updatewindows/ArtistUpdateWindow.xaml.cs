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
    /// Interaction logic for ArtistUpdateWindow.xaml
    /// </summary>
    public partial class ArtistUpdateWindow : Window
    {
        public Artist SelectedArtist { get; set; }
        public ArtistUpdateWindow(Artist selectedArtist)
        {
            SelectedArtist = selectedArtist;
            DataContext = selectedArtist;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
