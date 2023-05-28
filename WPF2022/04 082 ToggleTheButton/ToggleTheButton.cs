using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ToggleTheButton
{
    public class ToggleTheButton : Window//класс, производный от Window
    {
        [STAThread]//используется однопоточная модель
        public static void Main()
        {
            Application app = new Application();//создаем объект типа Application
            app.Run(new ToggleTheButton());//вызов метода Run, котрый запускает цикл сообщений
        }
        public ToggleTheButton()
        {
            Title = "Toggle the Button";//определяет текст заголовка окна
            ToggleButton btn = new ToggleButton();
            btn.Content = "Can _Resize";//текст кнопки
            btn.HorizontalAlignment = HorizontalAlignment.Center;//содержимое кнопки
            btn.VerticalAlignment = VerticalAlignment.Center;    //по центру
            btn.IsChecked = (ResizeMode == ResizeMode.CanResize);// свойство IsChecked обозначает текущее состояние
            btn.Checked += ButtonOnChecked;  //события включения
            btn.Unchecked += ButtonOnChecked;// и выключения
            Content = btn;
        }
        void ButtonOnChecked(object sender, RoutedEventArgs args)
        {
            ToggleButton btn = sender as ToggleButton; // объект ToggleButton используется для изменений свойств ResizeMode окна
            ResizeMode = (bool)btn.IsChecked ? ResizeMode.CanResize : ResizeMode.NoResize;
        } //кнопка используется для переключения свойства ResizeMode между значениями ResizeMode.CanResize и ResizeMode.NoResize 
    }
    }