using System.Numerics;
using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Windows.Controls;
using PropertyChanged;


using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        readonly ViewModel VM;
        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel(5);
             DataContext = VM;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border? border = sender as Border;
            VM.CurrentNumber = (border.Child as TextBlock).Text;
        }

        private void BorderMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }    

}
