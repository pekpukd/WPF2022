using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Petzold.RotateTheGradientOrigin
{
    public class RotateTheGradientOrigin : Window
    {
        RadialGradientBrush brush; //кисть с градиентой закраской
        double angle;
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); // создает новый элемент класса Application          
            app.Run(new RotateTheGradientOrigin());
        }
        public RotateTheGradientOrigin() //описание метода      
        {
            Title = "Rotate the Gradient Origin";   // название          
            WindowStartupLocation = WindowStartupLocation.CenterScreen;// начальное положение окна  (верхний леввй угол)         
            Width = 384;        // ie, 4 inches             
            Height = 384;
            brush = new RadialGradientBrush(Colors.White, Colors.Blue); // выбор цветов            
            brush.Center = brush.GradientOrigin = new Point(0.5, 0.5); // на какие части делим            
            brush.RadiusX = brush.RadiusY = 0.10; // скругление              
            brush.SpreadMethod = GradientSpreadMethod.Repeat;
            Background = brush;  //фон           
            DispatcherTimer tmr = new DispatcherTimer(); // создает новый элемент класса DispatcherTimer             
            tmr.Interval = TimeSpan.FromMilliseconds(100); // интервал            
            tmr.Tick += TimerOnTick; // на сколько изменится             
            tmr.Start();
        }
        void TimerOnTick(object sender, EventArgs args)
        {
            Point pt = new Point(0.5 + 0.05 * Math.Cos(angle), 0.5 + 0.05 * Math.Sin(angle));
            brush.GradientOrigin = pt;
            angle += Math.PI / 6;      // ie, 30  degrees         
        }
    }
}
