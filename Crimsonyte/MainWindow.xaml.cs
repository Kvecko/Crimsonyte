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

namespace Crimsonyte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string playerName;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btn_Name_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != "")
            {
                playerName = textbox.Text.ToString();
            }
            else
            {
                playerName = "Trailblazer";
            }
            Window windowBattle = new Battle();
            windowBattle.Show();
            this.Close();
        }
    }
}
