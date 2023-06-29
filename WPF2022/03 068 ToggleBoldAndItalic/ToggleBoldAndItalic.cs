//---------------------------------------------------- 
// ToggleBoldAndItalic.cs (c) 2006 by Charles Petzold 
//---------------------------------------------------- 
using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Documents; 
using System.Windows.Input; 
using System.Windows.Media; 

namespace Petzold.ToggleBoldAndItalic 
{     
    public class ToggleBoldAndItalic : Window//класс, производный от Window     
    {         
        [STAThread]//используется однопоточная модель         
        public static void Main()         
        {             
            Application app = new Application();//создаем объект типа Application             
            app.Run(new ToggleBoldAndItalic()); //вызов метода Run, котрый запускает цикл сообщений      
        }         
        public ToggleBoldAndItalic()         
        {             
            Title = "Toggle Bold & Italic"; //определяет текст заголовка окна            
            TextBlock text = new TextBlock();//колекция Inlines            
            text.FontSize = 32;  //размер шрифта           
            text.HorizontalAlignment =  HorizontalAlignment.Center;//содержимое по          
            text.VerticalAlignment =  VerticalAlignment.Center;    // центру         
            Content = text;  //содержимое            
            string strQuote = "To be, or not to be , that is the question";//целая фраза             
            string[] strWords = strQuote.Split();// разделение фразы по словам           
            foreach (string str in strWords) //проходка по словам            
            {                 
                Run run = new Run(str);//конструкторы Bold и Italic принимают только объекты Inline, по этому используем конструктор Run для каждого слова              
                run.MouseDown += RunOnMouseDown;//нажатие мыши = изменения шрифта                 
                text.Inlines.Add(run); //объединяем слова в коллекцию Inlines объекта TextBlock              
                text.Inlines.Add(" ");             
            }         
        }         
        void RunOnMouseDown(object sender,  MouseButtonEventArgs args)         
        {             
            Run run = sender as Run;             
            if (args.ChangedButton == MouseButton .Left) //изменение от нажатия левой клавиши                
                run.FontStyle = run.FontStyle ==  FontStyles.Italic ?                     
                    FontStyles.Normal : FontStyles .Italic;//курсивное начертание             
            if (args.ChangedButton == MouseButton .Right) //изменение от нажатия правой клавиши               
                run.FontWeight = run.FontWeight ==  FontWeights.Bold ?                     
                    FontWeights.Normal :  FontWeights.Bold;//полужирное начертание         
        }     
    } 
}
