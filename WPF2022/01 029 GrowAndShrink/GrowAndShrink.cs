//---------------------------------------------- 
// GrowAndShrink.cs (c) 2006 by Charles Petzold 
//---------------------------------------------- 
using System; 
using System.Windows; 
using System.Windows.Input; 
namespace Petzold.GrowAndShrink 
{     
    public class GrowAndShrink : Window //класс производный от Window
    {         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();  //создаем новый объект           
            app.Run(new GrowAndShrink());         //вызываем метод нового объекта, приложенние получает ввод пользователя с клаво-мыши.
        }         
        public GrowAndShrink()         
        {             
            Title = "Grow & Shrink";   //определяет текст заголовка          
            WindowStartupLocation =  WindowStartupLocation.CenterScreen;  //свойство-выравниет окно по центру рабочей области          
            Width = 192;             
            Height = 192;         
        }         
        protected override void OnKeyDown (KeyEventArgs args)  //метод реагирующий на нажатие клавиш        
        {                                                      //Объект KeyEventArgs , предоставляет данные о событии OnKeyDown(KeyEventArgs) .
            base.OnKeyDown(args);  //вызов метода базового класса, который был переопределен другим методом.          
            if (args.Key == Key.Up)  //метод реагирующий на отпускание клавиши
            {                 
                Left -= 0.05 * Width;           //изменение размера окна      
                Top -= 0.05 * Height;                 
                Width *= 1.1;                 
                Height *= 1.1;             
            }             
            else if (args.Key == Key.Down)   //метод реагирующий на нажатие клавиши          
            {                 
                Left += 0.05 * (Width /= 1.1);    //изменение размера окна              
                Top += 0.05 * (Height /= 1.1);             
            }         
        }     
    } 
} 

