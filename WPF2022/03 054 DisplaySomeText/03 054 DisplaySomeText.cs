using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;  // поможем определить цвет и стиль текста

    class DisplaySomeText : Window
{
    [STAThread]
    public static void Main()
    {
        Application app = new Application();
        app.Run(new DisplaySomeText());
    }

    public DisplaySomeText()   //метод класса DisplaySomeText
    {
        Title = "Display Some Text";  //заголовок окна
        Content = "Content can be simple text!"; //текст, который выводится на экран слева
        FontFamily = new FontFamily("Times New Roman");   //название шрифта, FontFamili - семейство связных гарнитур, гарнитура- разновидность семейств
        FontSize = 32;  //размер шрифта
        FontStyle = FontStyles.Oblique;  //наклон символов вправо 
        FontWeight = FontWeights.Bold;   //полужирный шрифт
        Brush brush = new LinearGradientBrush(Colors.Black, Colors.White, new Point(0, 0), new Point(1, 1)); // заливает фон окна
        Background = brush;  //задний план кисть
        Foreground = brush;  //передний план  кисть
    }
}
