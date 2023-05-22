using System;
using System.Windows;
using System.Windows.Controls;
namespace Petzold.ComputerDatingWizard
{
    public class Vitals
    {
        public string Name;
        public string Home;        //некоторые из полей являются производными от элементов управления RadioButton , 
        public string Gender;     // сгруппированных в StackPanel внутри GroupBox . Включение статического
        public string FavoriteOS;  // метода позволяет извлечь проверенный RadioButton из группы.  
        public string Directory;
        public string MomsMaidenName;
        public string Pet;
        public string Income;
        public static RadioButton
        GetCheckedRadioButton(GroupBox grpbox)
        {
            Panel pnl = grpbox.Content as Panel;
            if (pnl != null)
            {
                foreach (UIElement el in pnl.Children)
                {
                    RadioButton radio = el as RadioButton;
                    if (radio != null && (bool)radio.IsChecked)
                        return radio;
                }
            }
            return null;
        }
    }
}