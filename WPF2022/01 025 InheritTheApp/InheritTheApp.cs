using System;
using System.Windows;

namespace Petzold.InheritTheApp
{
    class InheritTheApp : Application
    {
        [STAThread]

        public static void Main()
        {
            InheritTheApp app = new InheritTheApp(); //создаем обьект класса InheritTheApp
            app.Run(); // запускаем приложение wpf
        }
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args); //вызов реализации базового класса

            Window win = new Window
            {
                Title = "Inherit the App" // название окна
            };
            win.Show();
        }

        /* событие SessionEnding происходит, когда пользователь завершает сеанс Windows,
        выходя из системы или завершая работу операционной системы.
        */
        protected override void OnSessionEnding(SessionEndingCancelEventArgs args)
        {
            base.OnSessionEnding(args);
            Console.WriteLine("hi"); // выдод надписи 

            MessageBoxResult result = MessageBox.Show(
                "Do you want to  save your data?",
                MainWindow.Title,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes
            );

            args.Cancel = result == MessageBoxResult.Cancel;
        }
    }
}
