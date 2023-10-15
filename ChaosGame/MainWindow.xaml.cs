using ChaosGameLib;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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


    private void Triangle_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosTriangle.CreateChaosTriangle(int.Parse(iterations!), System.Drawing.Color.Cyan);
        SetImage(image);
    }

    private void Square_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosSquare.CreateChaosSquare(int.Parse(iterations!), System.Drawing.Color.Cyan);
        SetImage(image);
    }

    private void Pentagon_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosPentagon.CreateChaosPentagon(int.Parse(iterations!), System.Drawing.Color.Cyan);
        SetImage(image);
    }

    private void Hexagon_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        string? iterations = menuItem.Tag as string;

        Bitmap image = ChaosHex.CreateChaosHex(int.Parse(iterations!), System.Drawing.Color.Cyan);
        SetImage(image);
    }

    /// <summary>
    /// Sets a bitmap as the source of an image
    /// </summary>
    /// <param name="image">Bitmap</param>
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
}
