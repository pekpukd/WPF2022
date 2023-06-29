using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.DiagonalizeTheButtons
{
    public class DiagonalizeTheButtons : Window//класс, производный от Window
    {
        [STAThread]//используется однопоточная модель
        public static void Main()
        {
            Application app = new Application();//создаем объект типа Application
            app.Run(new DiagonalizeTheButtons());//вызов метода Run, котрый запускает цикл сообщений
        }
        public DiagonalizeTheButtons()
        {
            Title = "Diagonalize the Buttons";//определение текста заголовка окна
            DiagonalPanel pnl = new DiagonalPanel();
            Content = pnl; Random rand = new Random();
            for (int i = 0; i < 5; i++)//создание кнопок
            {
                Button btn = new Button();
                btn.Content = "Button Number " + (i + 1);//содержимое кнопок
                btn.FontSize += rand.Next(20);
                pnl.Add(btn);
            }
        }
    }
}
