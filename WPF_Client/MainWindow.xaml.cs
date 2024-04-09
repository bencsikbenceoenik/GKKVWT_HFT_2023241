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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestService rest;
        List<Artist> artists;
        public MainWindow()
        {
            InitializeComponent();
            artists = new List<Artist>()
            {
                new Artist("1#BTS#1993-12-04#2013#Group#Male#South Korean#"),
                new Artist("2#BLACKPINK#1996-01-03#2016#Group#Female#South Korean#"),
                new Artist("3#EXO#1992-09-21#2012#Group#Male#South Korean#"),
                new Artist("4#TWICE#1999-02-01#2015#Group#Female#South Korean#"),
                new Artist("5#RED VELVET#1991-03-29#2014#Group#Female#South Korean#"),
                new Artist("6#ITZY#2000-08-20#2019#Group#Female#South Korean#"),
                new Artist("7#NCT 127#1995-07-01#2016#Group#Male#South Korean#"),
                new Artist("8#STRAY KIDS#2000-09-14#2018#Group#Male#South Korean#"),
                new Artist("9#EXID#1991-08-12#2012#Group#Female#South Korean#"),
                new Artist("10#MONSTA X#1993-01-26#2015#Group#Male#South Korean#"),
                new Artist("11#MAMAMOO#1991-06-19#2014#Group#Female#South Korean#"),
                new Artist("12#(G)I-DLE#1998-08-14#2018#Group#Female#South Korean#")
            };
            ltb.ItemsSource = artists;
        }
    }
}
