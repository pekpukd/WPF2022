//демонстрация привязки команд
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.CommandTheButton
{
    public class CommandTheButton : Window
    {
        [STAThread]  // используется один поток       
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CommandTheButton()); //запуск
        }
        public CommandTheButton()
        {
            Title = "Command the Button";             // Создадим кнопку и установим её в качестве содержимого окна            
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Command = ApplicationCommands.Paste;   //кнопка выполняет программу "вставить в буфер обмена"        
            btn.Content = ApplicationCommands.Paste.Text; //устанавливаем текст кнопки            
            Content = btn;             //Привязываем команду к обработчикам событий             
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste,//свойство с именем CommandBindings,которое представляет собой набор объектов CommandBinding
            PasteOnExecute, PasteCanExecute));                               //PasteOnExecute и PasteCanExecute — это два обработчика событий
        }                                                                 //В обработчике PasteOnExecute выполняем команду Paste(вставить)
        void PasteOnExecute(object sender, ExecutedRoutedEventArgs args) //обработчик PasteCanExecute проверяет буфер обмена на наличие данных в правильном формате
        {                                                                 //если данные не доступны,то обработчик устанавливает флаг и кнопка автоматически выключается
            Title = Clipboard.GetText();
        }
        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        { args.CanExecute = Clipboard.ContainsText(); }
        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            base.OnMouseDown(args);
            Title = "Command the Button";
        }
    }
}
