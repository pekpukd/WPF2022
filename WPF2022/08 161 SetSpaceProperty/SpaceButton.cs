using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SetSpaceProperty 
{
    public class SpaceButton : Button
    { 
        // Традиционное приватное поле .NET и открытое свойство
        string txt;         public string Text
        {
            set
            { 
                txt = value; 
                Content = SpaceOutText(txt);
            }
            get 
            {
                return txt; 
            } 
        }
        // DependencyProperty и открытое свойство
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
        // Статический конструктор
        static SpaceButton() 
        { 
            // Определение метаданных
            FrameworkPropertyMetadata metadata =  new FrameworkPropertyMetadata(); 
            metadata.DefaultValue = 1;
            metadata.AffectsMeasure = true;
            metadata.Inherits = true;
            metadata.PropertyChangedCallback +=  OnSpacePropertyChanged;
            // Регистрация DependencyProperty
            SpaceProperty =
                DependencyProperty.Register ("Space", typeof(int),
                typeof (SpaceButton), metadata,
                ValidateSpaceValue);
        }
        // Метод обратного вызова для проверки значения
        static bool ValidateSpaceValue(object obj)
        {
            int i = (int)obj;
            return i >= 0;
        }
        // Метод обратного вызова для оповещения изменении свойства
        static void OnSpacePropertyChanged (DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            SpaceButton btn = obj as SpaceButton; 
            btn.Content = btn.SpaceOutText(btn.txt);
        }
        // Метод для вставки пробелов в текст
        string SpaceOutText(string str) 
        {
            if (str == null) 
                return null;
            StringBuilder build = new StringBuilder();
            foreach (char ch in str) 
                build.Append(ch + new string(' ',  Space)); 
            return build.ToString();
        } 
    }
}
