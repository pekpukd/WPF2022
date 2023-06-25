/*
 Program dependencies:   <-- Need to include to blank c# project
    System
    PresentationCore
    PresentationCoreFramework
    System.Windows 
    WindowsBase 
    System.Xaml
*/

// -----------------------------------------
// SayHello.cs (c) 2006 by Charles Petzold
// -----------------------------------------

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
            win.Show(); // Display that white box to user on desktop
            Application app = new Application();
            app.Run(); //запускает цикл сообщений

            /*
              // Also the previous code can be simplified into:
              new Application().Run(new Window {Title = "Say Hello"});             
            */
        }
    }
}