using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.PaintTheButton
{
    public class PaintTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new PaintTheButton());
        }
        public PaintTheButton()
        {
            Title = "Paint the Button";
            // Создайте кнопку в качестве содержимого окна.
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn;
            // Создайте холст в качестве содержимого кнопки.
            Canvas canv = new Canvas();
            canv.Width = 144; // размеры
            canv.Height = 144; // размеры
            btn.Content = canv;
            // Создайте прямоугольник как дочерний элемент canvas.
            Rectangle rect = new Rectangle();
            rect.Width = canv.Width;
            rect.Height = canv.Height;
            rect.RadiusX = 24;
            rect.RadiusY = 24;
            rect.Fill = Brushes.Blue; // выбор цвета
            canv.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetRight(rect, 0);
            // Создайте полигон как дочерний элемент canvas.
            Polygon poly = new Polygon();
            poly.Fill = Brushes.Yellow; // цвет
            poly.Points = new PointCollection();
            // оесуем звезду 
            for (int i = 0; i < 5; i++)
            {
                double angle = i * 4 * Math.PI / 5;
                Point pt = new Point(48 * Math.Sin(angle), -48 * Math.Cos(angle));
                poly.Points.Add(pt);
            }
            canv.Children.Add(poly);
            Canvas.SetLeft(poly, canv.Width / 2);
            Canvas.SetTop(poly, canv.Height / 2);
        }
    }
}