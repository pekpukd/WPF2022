using System;
using System.Windows;
using System.Windows.Controls;
namespace Petzold.XamlCruncher
{
    public partial class XamlTabSpacesDialog
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new XamlTabSpacesDialog());
        }
        public XamlTabSpacesDialog()
        {
            InitializeComponent();
            txtbox.Focus();
        }
        public int TabSpaces//свойство которое напрямую обращается к свойству Text объекта TextBox
        {
            set { txtbox.Text = value.ToString(); }
            get { return Int32.Parse(txtbox.Text); }
        }
        void TextBoxOnTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;
            btnOk.IsEnabled = (Int32.TryParse(txtbox.Text, out result) && result > 0 && result < 11);
        }
        void OkOnClick(object sender, RoutedEventArgs args)
        {
            DialogResult = true;
        }
    }
}
