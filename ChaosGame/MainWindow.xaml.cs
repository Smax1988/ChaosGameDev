using ChaosGameLib;
using ChaosGameLib.Models;
using System.Windows;

namespace ChaosGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// After Canvas is loaded start ChaosGame
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLoad(object sender, RoutedEventArgs e)
    {
        //ChaosTriangle.CreateChaosTriangle(ChaosGameCanvas, 200000);
        ChaosSquare.CreateChaosSquare(ChaosGameCanvas, 100000);
    }
}
