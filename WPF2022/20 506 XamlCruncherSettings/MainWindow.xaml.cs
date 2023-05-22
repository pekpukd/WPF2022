using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Petzold.XamlCruncher
{
    public class XamlCruncherSettings : Window
    {
        // Настройки пользователя по умолчанию       
        public Dock Orientation = Dock.Left;
        public int TabSpaces = 4;
        public string StartupDocument = 
            "<Button xmlns=\"http://schemas .microsoft.com/winfx" + "/2006/xaml/presentation\" \r\n" +       
    "xmlns:x=\"http://schemas .microsoft.com/winfx" +  "/2006/xaml\">\r\n" + "    Hello, XAML!\r\n" +  "</Button>\r\n";    
// Конструктор для инициализации настроек по умолчанию в NotepadCloneSettings. (изменяет шрифт по умолчанию на 10-точечный фиксированный шаг консоли Lucida.)        
public XamlCruncherSettings()
        {
            FontFamily = "Lusida Console";
            FontSize = 10 / 0.75;
        }
    }
}
