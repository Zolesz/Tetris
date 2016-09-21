using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TetrisCore;
using TetrisGUI.TetrisObjects;

namespace TetrisGUI
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void doSomething(object sender, RoutedEventArgs e)
        {
            testLabel.Content = "doSomething called";
            tBoard.drawTetrisObject(0,0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tBoard.initializeBoard(20);
        }
    }
}
