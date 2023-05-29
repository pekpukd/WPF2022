
//--------------------------------------------------- 
// ExploreDirectories.cs (c) 2006 by Charles Petzold 
//--------------------------------------------------- 
using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.ExploreDirectories 
{     
    public class ExploreDirectories : Window//класс, производный от Window     
    {         
        [STAThread]//используется однопоточная модель         
        public static void Main()         
        {             
            Application app = new Application();//создаем объект типа Application             
            app.Run(new ExploreDirectories());//вызов метода Run, котрый запускает цикл сообщений         
        }         public ExploreDirectories()         
        {             Title = "Explore Directories";//определение текста заголовка окна             
            ScrollViewer scroll = new ScrollViewer();//содержимое окна             
            Content = scroll;             
            WrapPanel wrap = new WrapPanel();//содержимое ScrollViewer            
            scroll.Content = wrap;             
            wrap.Children.Add(new  FileSystemInfoButton());//дочерний элемент WrapPanel       
        }     
    } 
} 