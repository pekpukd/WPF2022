using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.FormatRichText
{
    public partial class FormatRichText : Window
    {
        RichTextBox txtbox;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatRichText());
        }
        public FormatRichText()
        {
            Title = "Format Rich Text";
            // Создвние объекта DockPanel как содержимого окна
            DockPanel dock = new DockPanel();
            Content = dock;
            // Создание области ToolBarTray у верхнего края окна
            ToolBarTray tray = new ToolBarTray();
            dock.Children.Add(tray);
            DockPanel.SetDock(tray, Dock.Top);
            // Создание объекта RichTextBox
            txtbox = new RichTextBox();
            txtbox.VerticalScrollBarVisibility =  ScrollBarVisibility.Auto;
            // Вызов методов из других файлов
            AddFileToolBar(tray, 0, 0);
            AddEditToolBar(tray, 1, 0);
            AddFileToolBar(tray, 2, 0);
            AddFileToolBar(tray, 2, 1);
            // Создание объекта RichTextBox заполняющего
            // остальную площадь и передачу ему фокуса
            dock.Children.Add(txtbox);
            txtbox.Focus();
        }
    }
}
