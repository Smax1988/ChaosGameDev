using ChaosGameLib;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

    private void Triangle_Click(object sender, RoutedEventArgs e)
    {
        ChaosGameCanvas.Children.Clear();

        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        ChaosTriangle.CreateChaosTriangle(ChaosGameCanvas, int.Parse(iterations!));
    }

    private void Square_Click(object sender, RoutedEventArgs e)
    {
        ChaosGameCanvas.Children.Clear();

        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        ChaosSquare.CreateChaosSquare(ChaosGameCanvas, int.Parse(iterations!));
    }

    private void Hexagon_Click(object sender, RoutedEventArgs e)
    {
        ChaosGameCanvas.Children.Clear();

        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        ChaosHex.CreateChaosHex(ChaosGameCanvas, int.Parse(iterations!));
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        //canvasParent.Children.Remove(ChaosGameCanvas);

        //Canvas newCanvas = new Canvas
        //{
        //    Name = "ChaosGameCanvas",
        //    Background = new SolidColorBrush(Colors.Black)
        //};

        //canvasParent.Children.Add(newCanvas);
    }
}
