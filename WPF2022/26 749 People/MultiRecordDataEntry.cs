//using Petzold.SingleRecordDataEntry;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.MultiRecordDataEntry
{
    public partial class MultiRecordDataEntry
    {
       // SingleRecordDataEntry people;
        int index;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MultiRecordDataEntry());
        }
        public MultiRecordDataEntry()
        {
            InitializeComponent();
            // Имитация команды File>New 
            ApplicationCommands.New.Execute(null,  this);
            // Передача фокуса первому элементу TextBox на панели
            // pnlPerson.Children[1].Focus();
        }
        // Обработчик событий команд в меню
        void NewOnExecuted(object sender,  ExecutedRoutedEventArgs args)
        {
            //people = new SingleRecordDataEntry();
            InitializeNewPeopleObject();
        }
        void OpenOnExecuted(object sender,  ExecutedRoutedEventArgs args)
        {
            //people = SingleRecordDataEntry.Load(this);
            InitializeNewPeopleObject();
        }
        void SaveOnExecuted(object sender,  ExecutedRoutedEventArgs args)
        {
            //people.Save(this);
        }
        void InitializeNewPeopleObject()
        {
            index = 0;
           // if (people.Count == 0)
           //     people.Insert(0, new Person());
           // pnlPerson.DataContext = people[0];
            EnableAndDisableButtons();
        }
        // Обработчик событий для кнопок
        void FirstOnClick(object sender,  RoutedEventArgs args)
        {
           // pnlPerson.DataContext = people[index = 0];
            EnableAndDisableButtons();
        }
        void PrevOnClick(object sender,  RoutedEventArgs args)
        {
           // pnlPerson.DataContext = people[index  -= 1];
            EnableAndDisableButtons();
        }
        void NextOnClick(object sender,  RoutedEventArgs args) 
        {
           // pnlPerson.DataContext = people[index  += 1];
            EnableAndDisableButtons();
        }
        void LastOnClick(object sender,  RoutedEventArgs args)
        {
            //pnlPerson.DataContext = people[index =  people.Count - 1];
            EnableAndDisableButtons();
        }
        void AddOnClick(object sender,  RoutedEventArgs args)
        {
           // people.Insert(index = people.Count,  new Person());
           // pnlPerson.DataContext = people[index];
            EnableAndDisableButtons();
        }
        void DelOnClick(object sender,  RoutedEventArgs args)
        {
           // people.RemoveAt(index);
           // if (people.Count == 0)
           //     people.Insert(0, new Person());
           // if (index > people.Count - 1)
                index--;
            //pnlPerson.DataContext = people[index];
            EnableAndDisableButtons();
        }
        void EnableAndDisableButtons()
        {
            btnPrev.IsEnabled = index != 0;
           // btnNext.IsEnabled = index < people .Count - 1;
           // pnlPerson.Children[1].Focus();
        }
    }
}
