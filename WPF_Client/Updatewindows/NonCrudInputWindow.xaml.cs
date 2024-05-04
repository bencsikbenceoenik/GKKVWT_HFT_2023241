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
    /// Interaction logic for NonCrudInputWindow.xaml
    /// </summary>
    public partial class NonCrudInputWindow : Window
    {
        public string _input1 { get; set; }
        public string _input2 { get; set; }
        public NonCrudInputWindow(int num)
        {
            InitializeComponent();
            Label label1 = new Label();
            TextBox input1 = new TextBox();
            Label label2 = new Label();
            TextBox input2 = new TextBox();
            switch (num)
            {
                case 1:
                    label1.Content = "durationThreshold";
                    label2.Content = "artistGender";
                    noncrudstp.Children.Add(label1);
                    noncrudstp.Children.Add(input1);
                    noncrudstp.Children.Add(label2);
                    noncrudstp.Children.Add(input2);
                    break;
                case 2:
                    label1.Content = "debutYearThreshold";
                    noncrudstp.Children.Add(label1);
                    noncrudstp.Children.Add(input1);
                    break;
                case 3:
                    label1.Content = "thresholdValue";
                    noncrudstp.Children.Add(label1);
                    noncrudstp.Children.Add(input1);
                    break;
                case 4:
                    label1.Content = "releaseYear";
                    label2.Content = "nationality";
                    noncrudstp.Children.Add(label1);
                    noncrudstp.Children.Add(input1);
                    noncrudstp.Children.Add(label2);
                    noncrudstp.Children.Add(input2);
                    break;
                case 5:
                    label1.Content = "artistName";
                    label2.Content = "labelName";
                    noncrudstp.Children.Add(label1);
                    noncrudstp.Children.Add(input1);
                    noncrudstp.Children.Add(label2);
                    noncrudstp.Children.Add(input2);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
