using System; 
using System.Windows; 
using System.Windows.Input; 
namespace Petzold.InheritAppAndWindow 
{

    class InheritAppAndWindow
    {
        [STAThread]
        public static void Main()
        {
            MyApplication app = new MyApplication();
            app.Run();
        }
    }
    class MyApplication : Application     
    {         
        protected override void OnStartup (StartupEventArgs args)         
        {             
            base.OnStartup(args);             
            Window win = new Window();             
            win.Show();         
        }     
    } 
}