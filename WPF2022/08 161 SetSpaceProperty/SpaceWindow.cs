using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SetSpaceProperty
{ public class SpaceWindow : Window
    {
        // DependencyProperty и свойство
        public static readonly DependencyProperty  SpaceProperty;
        public int Space
        {
            set
            { 
                SetValue(SpaceProperty, value); 
            }
            get
            {
                return (int)GetValue(SpaceProperty);
            } 
        } 
        //Статистический конструктор
        static SpaceWindow()
        {
            //Определение метаданных
            FrameworkPropertyMetadata metadata =  new FrameworkPropertyMetadata(); 
            metadata.Inherits = true;
            // Добавление владельца к SpaceProperty
            // и переопределение метаданных
            SpaceProperty =
                SpaceButton.SpaceProperty.AddOwner (typeof(SpaceWindow));
            SpaceProperty.OverrideMetadata(typeof (SpaceWindow), metadata);
        }
    }
}
