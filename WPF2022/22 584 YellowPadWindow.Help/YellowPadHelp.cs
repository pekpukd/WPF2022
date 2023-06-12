using System;
using System.Windows;
using System.Windows.Controls;
namespace Petzold.YellowPad
{
    public partial class YellowPadHelp
    {
        public YellowPadHelp()
        {
            // InitializeComponent();
            //Выделение первого элемента в объекте TreeView и передача ему фокуса
            // (tree.Items[0] as TreeViewItem) .IsSelected = true;
            // tree.Focus();
        }
        void HelpOnSelectedItemChanged(object sender,
            RoutedPropertyChangedEventArgs<object> args)
        {
            TreeViewItem item = args.NewValue as  TreeViewItem;
            if (item.Tag == null)
                return;
            // Перезод  по свойству Tag выделенного элемента
           // frame.Navigate(new Uri(item.Tag as  string, UriKind.Relative));
        }
    }
}

