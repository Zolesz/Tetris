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
        ucBoard _ucBoard = new ucBoard();

        public MainWindow()
        {
            InitializeComponent();
            _ucBoard.initializeBoard(20);
        }

        public void doSomething(object sender, RoutedEventArgs e)
        {
            _ucBoard.ChangeTile(10, 10);
        }

    }
}
