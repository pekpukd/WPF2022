
//------------------------------------------------- 
// RenderTheGraphic.cs (c) 2006 by Charles Petzold 
//-------------------------------------------------
using System;
using System.Windows;
namespace Petzold.RenderTheGraphic
{
    class RenderTheGraphic : Window
    {
        [STAThread]   //используется один поток      
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RenderTheGraphic());   //запуск      
        }
        public RenderTheGraphic()
        {
            Title = "Render the Graphic";
            SimpleEllipse elips = new SimpleEllipse();     // создаём объект SimpleEllipse       
            Content = elips;  // устанавливаем свойство content       
        }
    }
}


