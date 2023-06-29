using System;
using System.Collections; // для IList. 
using System.Collections.Specialized;  // для  NotifyCollectionChangedEventArgs.
using System.ComponentModel;          // для ICollectionView. 
using System.Reflection;                // для ConstructorInfo.
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.CSharp.RuntimeBinder;
using Binder = System.Reflection.Binder;
using ToolBar = System.Windows.Controls.ToolBar;

namespace Petzold.DataEntry
{
    public partial class NavigationBar : ToolBar
    {
        IList coll;
        ICollectionView collview;
        Type typeItem;
        // Public constructor.       
        public NavigationBar()
        {
            InitializeComponent();
        }
        // Public свойства     
        public IList Collection
        {
            set
            {
                coll = value;
                // Создаём CollectionView и устанавливаем обработчик событий         
                collview = CollectionViewSource.GetDefaultView(coll);
                collview.CurrentChanged += CollectionViewOnCurrentChanged;
                collview.CollectionChanged += CollectionViewOnCollectionChanged;            // Вызов обработчика событий для инициализации TextBox and Buttons.          
                CollectionViewOnCurrentChanged(null, null);
                // инициализация TextBlock.         
                txtblkTotal.Text = coll.Count.ToString();
            }
            get
            {
                return coll;
            }
        }
        // Этот тип элемента коллекции используется для команды "Добавить" 
        public Type ItemType
        {
            set { typeItem = value; }
            get { return typeItem; }
        }
        // Обработчики событий для CollectionView.    
        void CollectionViewOnCollectionChanged(object sender,
        NotifyCollectionChangedEventArgs args)
        {
            txtblkTotal.Text = coll.Count.ToString();
        }
        void CollectionViewOnCurrentChanged(object sender, EventArgs args)
        {
            txtboxCurrent.Text = (1 + collview.CurrentPosition).ToString();
            btnPrev.IsEnabled = collview.CurrentPosition > 0;
            btnNext.IsEnabled = collview.CurrentPosition < coll.Count - 1;
            Binder.IsEnabled = coll.Count > 1;
        }
        // Обработчики событий для кнопок.     
        void FirstOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToFirst();
        }
        void PreviousOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToPrevious();
        }
        void NextOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToNext();
        }
        void LastOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToLast();
        }
        void AddOnClick(object sender, RoutedEventArgs args)
        {
            ConstructorInfo info = typeItem.GetConstructor(System.Type.EmptyTypes);
            coll.Add(info.Invoke(null));
            collview.MoveCurrentToLast();
        }
        void DeleteOnClick(object sender, RoutedEventArgs args)
        {
            coll.RemoveAt(collview.CurrentPosition);
        }
        // Обработчики событий для txtboxCurrent TextBox.      
        string strOriginal;
        private object txtblkTotal;
        private object txtboxCurrent;

        void TextBoxOnGotFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            strOriginal = txtboxCurrent.Text;
        }
        void TextBoxOnLostFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            int current;
            if (Int32.TryParse(txtboxCurrent.Text, out current))
                if (current > 0 && current <= coll.Count)
                    collview.MoveCurrentToPosition(current - 1);
                else
                    txtboxCurrent.Text = strOriginal;
        }
        void TextBoxOnKeyDown(object sender, System.Windows.Forms.KeyEventArgs args)
        {
            if (args.Key == Key.Escape)
            {
                txtboxCurrent.Text = strOriginal;
                args.Handled = true;
            }
            else if (args.Key == Key.Enter)
            {
                args.Handled = true;
            }
            else
                return;
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
        }
    }
}