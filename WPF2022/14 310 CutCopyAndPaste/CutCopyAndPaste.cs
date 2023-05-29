using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Petzold.CutCopyAndPaste
{
    public class CutCopyAndPaste : Window//класс, производный от Window
    {
        TextBlock text;
        protected MenuItem itemCut, itemCopy, itemPaste, itemDelete;//элементы меню
        [STAThread]//используется однопоточная модель
        public static void Main()
        {
            Application app = new Application();//создаем объект типа Application
            app.Run(new CutCopyAndPaste());//вызов метода Run, котрый запускает цикл сообщений
        }
        public CutCopyAndPaste()
        {
            Title = "Cut, Copy, and Paste";//определение текста заголовка окна
            // создание объекта DockPanel.
            DockPanel dock = new DockPanel();
            Content = dock;
            // создание меню
            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);//прсоединенного к верхнему краю окна
            // создание объекта TextBlock заполняющего оставшуюся площадь
            text = new TextBlock();
            text.Text = "Sample clipboard text";//содержимое
            text.HorizontalAlignment =  HorizontalAlignment.Center;//по центру
            text.VerticalAlignment =  VerticalAlignment.Center;
            text.FontSize = 32;
            text.TextWrapping = TextWrapping.Wrap;
            dock.Children.Add(text);
            // создание меню Edit 
            MenuItem itemEdit = new MenuItem();
            itemEdit.Header = "_Edit";
            itemEdit.SubmenuOpened += EditOnOpened;
            menu.Items.Add(itemEdit);
            // создание команд меню
            itemCut = new MenuItem();
            itemCut.Header = "Cu_t";
            itemCut.Click += CutOnClick;
            Image img = new Image();
            img.Source = new BitmapImage(//иконка действия вырезка
                new Uri("https://w7.pngwing.com/pngs/483/285/png-transparent-cut-copy-and-paste-copying-computer-icons-clipboard-cut-angle-window-clipboard.png"));
            itemCut.Icon = img;
            itemEdit.Items.Add(itemCut);
            itemCopy = new MenuItem();
            itemCopy.Header = "_Copy";
            itemCopy.Click += CopyOnClick;
            img = new Image();
            img.Source = new BitmapImage(//иконка действия копирование
                new Uri("https://w7.pngwing.com/pngs/75/597/png-transparent-computer-icons-clipboard-cut-copy-and-paste-symbol-miscellaneous-angle-text.png"));
            itemCopy.Icon = img;
            itemEdit.Items.Add(itemCopy);
            itemPaste = new MenuItem();
            itemPaste.Header = "_Paste";
            itemPaste.Click += PasteOnClick;
            img = new Image();
            img.Source = new BitmapImage(//иконка действия вставка
                new Uri("https://w7.pngwing.com/pngs/124/792/png-transparent-computer-icons-cut-copy-and-paste-clipboard-icon-design-font-symbol-miscellaneous-text-logo.png"));
            itemPaste.Icon = img;
            itemEdit.Items.Add(itemPaste);
            itemDelete = new MenuItem();
            itemDelete.Header = "_Delete";
            itemDelete.Click += DeleteOnClick;
            img = new Image();
            img.Source = new BitmapImage(//иконка действия удаление
                new Uri("https://w7.pngwing.com/pngs/271/838/png-transparent-computer-icons-delete-icon-white-text-logo.png"));
            itemDelete.Icon = img;
            itemEdit.Items.Add(itemDelete);
        }
        void EditOnOpened(object sender,  RoutedEventArgs args)
        {
            itemCut.IsEnabled = 
                
                itemCopy.IsEnabled =
                itemDelete.IsEnabled = text.Text !=  null && text.Text.Length > 0;
            itemPaste.IsEnabled = Clipboard .ContainsText();
        }
        protected void CutOnClick(object sender,  RoutedEventArgs args)
        {
            CopyOnClick(sender, args);
            DeleteOnClick(sender, args);
        }
        protected void CopyOnClick(object sender,  RoutedEventArgs args)
        {
            if (text.Text != null && text.Text. Length > 0)
                Clipboard.SetText(text.Text);
        }
        protected void PasteOnClick(object sender,  RoutedEventArgs args)
        {
            if (Clipboard.ContainsText())
                text.Text = Clipboard.GetText();
        }
        protected void DeleteOnClick(object sender , RoutedEventArgs args)
        {
            text.Text = null;
        }
    }
}
