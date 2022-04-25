using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DuplicateUniformGrid
{
    public class DuplicateUniformGrid : Window  //класс наслежник от класса widows
    {
        [STAThread] //использует один поток
        public static void Main() 
        {
            Application app = new Application();  //создает объект типо Application
            app.Run(new DuplicateUniformGrid());  //запуск
        }
        public DuplicateUniformGrid() //публичный класс
        {
            Title = "Duplicate Uniform Grid";  //название окна
            // Создание объекта как содержимое окна.
            Grid unigrid = new  Grid(); 
            unigrid.Column = 5; //здесь возникли проблемы, не смогла разобраться
            Content = unigrid;
            
            // Заполнение кнопками случайного размера.
            Random rand = new Random(); 
            for (int index = 0; index < 48; index++) //цикл, перебирающий индекс элемента от 0 до 48, шагом +1 
            {
                Button btn = new Button(); //в .btn классы предназначены для использования Button ( обычная кнопка )
                btn.Name = "Button" + index; //имя кнопки "Button + индекс"
                btn.Content = btn.Name; 
                btn.FontSize += rand.Next(10); //размер шрифта
                unigrid.Children.Add(btn);  
            } 

            AddHandler(Button.ClickEvent,  //связывает событие с обработчиком событий во время выполнения.
                new  RoutedEventHandler(ButtonOnClick)); //перенаправление события
        } 
        void ButtonOnClick(object sender,  RoutedEventArgs args)   
        { 
            Button btn = args.Source as Button;  
            MessageBox.Show(btn.Name + " has  been clicked", Title); //отображает окно сообщение с текстом "номер + has been clicked" 
        } 
    } 
} 
