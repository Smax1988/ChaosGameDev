using ChaosGameLib;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChaosGame;

/// <summary>
/// Interaction logic for MainWindow.xaml TEST
/// </summary>
public partial class MainWindow : Window
{
    private readonly int imgWidth = 1000;
    private readonly int imgHeight = 800;


    public MainWindow()
    {
        InitializeComponent();
    }


    private void Triangle_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        using MemoryStream stream = ChaosTriangle.CreateTriangleMemoryStream(int.Parse(iterations!), imgWidth, imgHeight, System.Drawing.Color.Cyan);
        ChaosImage.Source = ConvertMemoryStreamToBitmapImage(stream);
    }

    private void Square_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        using MemoryStream stream = ChaosSquare.CreateSquareMemoryStream(int.Parse(iterations!), imgWidth, imgHeight, System.Drawing.Color.Cyan);
        ChaosImage.Source = ConvertMemoryStreamToBitmapImage(stream);
    }

    private void Pentagon_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        using MemoryStream stream = ChaosPentagon.CreatePentagonMemoryStream(int.Parse(iterations!), imgWidth, imgHeight, System.Drawing.Color.Cyan);
        ChaosImage.Source = ConvertMemoryStreamToBitmapImage(stream);
    }

    private void Hexagon_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        using MemoryStream stream = ChaosHexagon.CreateHexagonMemoryStream(int.Parse(iterations!), imgWidth, imgHeight, System.Drawing.Color.Cyan);
        ChaosImage.Source = ConvertMemoryStreamToBitmapImage(stream);
    }

    // CHANGE COLOR
    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ChaosImage == null || ChaosImage.Source == null) return;

        string? color = ((ComboBoxItem)colorComboBox.SelectedItem).Content.ToString();
        if (Enum.TryParse(color, out KnownColor knownColor))
        {
            System.Drawing.Color newColor = System.Drawing.Color.FromKnownColor(knownColor);
            BitmapSource bitmapSource = (BitmapSource)ChaosImage.Source;

            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = bitmapSource;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Bgra32;
            newFormatedBitmapSource.EndInit();

            int stride = newFormatedBitmapSource.PixelWidth * (newFormatedBitmapSource.Format.BitsPerPixel / 8);
            int size = newFormatedBitmapSource.PixelHeight * stride;
            byte[] pixelByteArray = new byte[size];
            newFormatedBitmapSource.CopyPixels(pixelByteArray, stride, 0);

            for (int i = 0; i < pixelByteArray.Length; i += 4)
            {
                if (pixelByteArray[i] != 0 || pixelByteArray[i + 1] != 0 || pixelByteArray[i + 2] != 0) // Check if the pixel is not black
                {
                    pixelByteArray[i] = newColor.B;
                    pixelByteArray[i + 1] = newColor.G;
                    pixelByteArray[i + 2] = newColor.R;
                }
            }

            WriteableBitmap writeableBitmap = new WriteableBitmap(newFormatedBitmapSource.PixelWidth, newFormatedBitmapSource.PixelHeight, newFormatedBitmapSource.DpiX, newFormatedBitmapSource.DpiY, PixelFormats.Bgra32, null);
            writeableBitmap.WritePixels(new Int32Rect(0, 0, newFormatedBitmapSource.PixelWidth, newFormatedBitmapSource.PixelHeight), pixelByteArray, stride, 0);
            ChaosImage.Source = writeableBitmap;
        }
    }

    // ZOOMING
    private double scaleFactor = 1.0;
    private double scaleIncrement = 0.2;
    private double minScale = 1.0;

    private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (ChaosImage.Source == null) return; 

        if (e.Delta > 0) // Zoom in
        {
            scaleFactor += scaleIncrement;
        }
        else // Zoom out
        {
            if (scaleFactor > minScale) // Limit the minimum zoom level
            {
                scaleFactor -= scaleIncrement;
            }
        }
        ScaleImage();
    }

    private void ScaleImage()
    {
        if (ChaosImage.LayoutTransform is ScaleTransform scaleTransform)
        {
            scaleTransform.ScaleX = scaleFactor;
            scaleTransform.ScaleY = scaleFactor;
        }
        else
        {
            ScaleTransform newTransform = new ScaleTransform(scaleFactor, scaleFactor);
            ChaosImage.LayoutTransform = newTransform;
        }
    }

    private static BitmapImage ConvertMemoryStreamToBitmapImage(MemoryStream memoryStream)
    {
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        return bitmapImage;
    }
}
