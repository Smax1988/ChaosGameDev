using ChaosGameLib;
using ChaosGameLib.Models;
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

namespace ChaosGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Triangle triangle = new Triangle();
        public MainWindow()
        {
            InitializeComponent();
            triangle.AddPoint(ChaosGameCanvas, new Coordinates { X = 100, Y = 100 });
            triangle.CreateInitialTriangle(ChaosGameCanvas);
        }



        
    }
}
