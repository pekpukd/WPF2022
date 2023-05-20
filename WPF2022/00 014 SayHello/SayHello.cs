using System;
using System.Windows; // пространство имен, вкл в себя все основные классы wpf

namespace Petzold.SayHello
{
    class SayHello
    {
        [STAThread] // Program will use single-threaded model to run
        public static void Main()
        {
            Window win = new Window(); // Инициализация нового обхекта Окно
            win.Title = "Say Hello"; // заголовок для окна
            win.Show();
            Application app = new Application();
            app.Run(); //запускает цикл сообщений

            /*
             
            */
        }
    }
}