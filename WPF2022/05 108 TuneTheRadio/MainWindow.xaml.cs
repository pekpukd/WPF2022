using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.TuneTheRadio
{
    public class TuneTheRadio : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TuneTheRadio());
        }
        public TuneTheRadio()
        {
            Title = "Tune the Radio";
            SizeToContent = SizeToContent.WidthAndHeight;
            GroupBox group = new GroupBox();
            group.Header = "Window Style";    // используем свойство Header, чтобы установить заголовок в верхней части GroupBox    
            group.Margin = new Thickness(96);
            group.Padding = new Thickness(5);
            Content = group;
            StackPanel stack = new StackPanel();      // помещаем четыре переключателя в групповое поле с помощью StackPanel 
            group.Content = stack;                    //(переключатели позволяют динамически изменять свойства окна WindowStyle)
            stack.Children.Add(CreateRadioButton("No border or  caption", WindowStyle.None));             // Метод CreateRadioButton предоставляет Содержимому каждой кнопки 
            stack.Children.Add(CreateRadioButton("Single-border  window", WindowStyle.SingleBorderWindow));//текстовую строку и присваивает свойству Tag соответствующий член            
            stack.Children.Add(CreateRadioButton("3D-border window", WindowStyle.ThreeDBorderWindow));      // перечисления WindowStyle       
            stack.Children.Add(CreateRadioButton("Tool window", WindowStyle.ToolWindow));
            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioOnChecked));
        }
        RadioButton CreateRadioButton(string strText, WindowStyle winstyle)
        {
            RadioButton radio = new RadioButton();
            radio.Content = strText;
            radio.Tag = winstyle;
            radio.Margin = new Thickness(5);
            radio.IsChecked = (winstyle == WindowStyle);
            return radio;
        }
        void RadioOnChecked(object sender, RoutedEventArgs args)
        {
            RadioButton radio = args.Source as RadioButton;
            WindowStyle = (WindowStyle)radio.Tag;
        }
    }
}