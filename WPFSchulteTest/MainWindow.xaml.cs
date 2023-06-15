using System.Numerics;
using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Windows.Controls;
using PropertyChanged;


using System.Windows.Media;
using System.Windows.Data;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        ViewModel VM;
        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel(2);
            DataContext = VM;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border? border = sender as Border;
            VM.CurrentNumber = (border.Child as TextBlock).Text;
        }
    }    

}
