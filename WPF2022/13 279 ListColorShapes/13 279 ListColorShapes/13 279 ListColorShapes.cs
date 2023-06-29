//------------------------------------------------
// ListColorShapes.cs (c) 2006 by Charles Petzold
//------------------------------------------------
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ListColorShapes
{
    class ListColorShapes : Window//класс, производный от Window
    {
        [STAThread]//используется однопоточная модель
        public static void Main()
        {
            Application app = new Application();//создаем объект типа Application
            app.Run(new ListColorShapes());//вызов метода Run, котрый запускает цикл сообщений
        }
        public ListColorShapes()
        {
            Title = "List Color Shapes";//определение текста заголовка окна

            ListBox lstbox = new ListBox();// содержимое окна, объект класса ListBox
            lstbox.Width = 150;// параметры ListBox
            lstbox.Height = 150;
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;
            Content = lstbox;
           
            PropertyInfo[] props = typeof(Brushes).GetProperties();// заполнение эллипсами
            foreach (PropertyInfo prop in props)
            {
                Ellipse ellip = new Ellipse();// объект класса эллипсов
                ellip.Width = 100;// параметры эллипса
                ellip.Height = 25;
                ellip.Margin = new Thickness(10, 5, 0, 5);
                ellip.Fill = prop.GetValue(null, null) as Brush;
                lstbox.Items.Add(ellip);//включение вариантов в колекцию Items
            }
        }
        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox;
            if (lstbox.SelectedIndex != -1)
                Background = (lstbox.SelectedItem as Shape).Fill;// привязка свойства к Background 
        }
    }
}