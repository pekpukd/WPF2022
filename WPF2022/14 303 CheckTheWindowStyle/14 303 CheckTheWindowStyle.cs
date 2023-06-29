using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.CheckTheWindowStyle
{
    public class CheckTheWindowStyle : Window
    {
        MenuItem itemChecked;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CheckTheWindowStyle());
        }
        public CheckTheWindowStyle()
        {
            Title = "Check the Window Style";
            // Создаём DockPanel.      
            DockPanel dock = new DockPanel();
            Content = dock;
            // Создание меню,закрепленное сверху     
            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);
            // Создаём TextBlock, заполняя всё остальное.    
            TextBlock text = new TextBlock();
            text.Text = Title;
            text.FontSize = 32;
            text.TextAlignment = TextAlignment.Center;
            dock.Children.Add(text);
            // Создаём объекты MenuItem для изменения  WindowStyle.    
            MenuItem itemStyle = new MenuItem();
            itemStyle.Header = "_Style";
            menu.Items.Add(itemStyle);
            itemStyle.Items.Add(CreateMenuItem("_No border or  caption", WindowStyle.None));
            itemStyle.Items.Add(CreateMenuItem("_Single-border  window", WindowStyle.SingleBorderWindow));
            itemStyle.Items.Add(CreateMenuItem("3_D-border window", WindowStyle.ThreeDBorderWindow));
            itemStyle.Items.Add(CreateMenuItem("_Tool window", WindowStyle.ToolWindow));
        }
        MenuItem CreateMenuItem(string str, WindowStyle style)  // Поскольку четыре элемента, отображаемые в меню «Style», довольно похожи
        {                                                        //и используют один и тот же обработчик событий Click 
            MenuItem item = new MenuItem();                          //программа определяет небольшой метод с именем CreateMenuItem специально для создания этих элементов
            item.Header = str;
            item.Tag = style;
            item.IsChecked = (style == WindowStyle);
            item.Click += StyleOnClick;
            if (item.IsChecked)
                itemChecked = item;
            return item;
        }
        void StyleOnClick(object sender, RoutedEventArgs args)
        {
            itemChecked.IsChecked = false;
            itemChecked = args.Source as MenuItem;
            itemChecked.IsChecked = true;//Если конкретный член перечисления WindowStyle совпадает со свойством WindowStyle окна , метод устанавливает для свойства IsChecked значение true , а также устанавливает поле itemChecked для этого элемента.           
            WindowStyle = (WindowStyle)itemChecked.Tag; //Обработчик события Click снимает отметку с элемента itemChecked , 
                                                        // устанавливает для элемента itemChecked выбранный элемент и завершает работу установкой свойства WindowStyle 
                                                        // окна на основе свойства Tag выбранного элемента.   
        }
    }
}
