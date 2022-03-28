//-------------------------------------------------- 
// AdjustTheGradient.cs (c) 2006 by Charles Petzold 
//--------------------------------------------------
// hacked by egor_dolgoshein
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace Petzold.AdjustTheGradient
{
    class AdjustTheGradient : Window // класс-наследник от класса window
    {
        LinearGradientBrush brush;
        [STAThread] // используется один поток
        public static void Main()
        {
            Application app = new Application(); // создаем объект типа Application
            app.Run(new AdjustTheGradient()); // запуск 
        }
        public AdjustTheGradient()
        {
            Title = "Adjust the Gradient"; // название окна
            SizeChanged += WindowOnSizeChanged; // размеры окна
            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0); // цветовая гамма того что в окне
            brush.MappingMode = BrushMappingMode.Absolute;
            Background = brush;
        }
        void WindowOnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight - SystemParameters.CaptionHeight;
            Point ptCenter = new Point(width / 2, height / 2);
            Vector vectDiag = new Vector(width, -height);
            Vector vectPerp = new Vector(vectDiag.Y, -vectDiag.X);
            vectPerp.Normalize(); vectPerp *= width * height / vectDiag.Length;
            brush.StartPoint = ptCenter + vectPerp;
            brush.EndPoint = ptCenter - vectPerp;
        }
    }
}