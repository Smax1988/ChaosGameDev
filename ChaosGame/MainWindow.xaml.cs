using ChaosGameLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

    private void SetImage(Bitmap image)
    {
        using MemoryStream memory = new MemoryStream();
        image.Save(memory, ImageFormat.Bmp);
        memory.Position = 0;
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();

        ChaosImage.Source = bitmapImage;
    }

    private void Triangle_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosTriangle.CreateChaosTriangle(int.Parse(iterations!), Color.Cyan);
        SetImage(image);
    }

    private void Square_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosSquare.CreateChaosSquare(int.Parse(iterations!), Color.Cyan);
        SetImage(image);
    }

    private void Hexagon_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosHex.CreateChaosHex(int.Parse(iterations!), Color.Cyan);
        SetImage(image);
    }
}
