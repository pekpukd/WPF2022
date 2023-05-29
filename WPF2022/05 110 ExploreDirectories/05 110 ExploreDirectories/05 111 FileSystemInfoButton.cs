//----------------------------------------------------- 
// FileSystemInfoButton.cs (c) 2006 by Charles Petzold 
//----------------------------------------------------- 
using System; using System.Diagnostics;       
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ExploreDirectories
{     
    public class FileSystemInfoButton : Button //класс, производный от Button    
    {         FileSystemInfo info;                  
        public FileSystemInfoButton()// конструктор создает кнопку для каталога "Мои документы"               
            :             
            this(new DirectoryInfo(                 
                Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments)))         
        {         
        }                      
        public FileSystemInfoButton(FileSystemInfo  info)// конструктор с одним аргументом создает кнопку для каталога или файла     
        {             
            this.info = info;             
            Content = info.Name;//содержимое-имя объекта             
            if (info is DirectoryInfo)//если обьект info представляет каталог                  
                FontWeight = FontWeights.Bold;//шрифт             
            Margin = new Thickness(10);         }//поля             
        public FileSystemInfoButton(FileSystemInfo  info, string str)//конструктор с двумя аргументами создает кнопку для вовращения к родительскому каталогу             
            :             
            this(info)         
        {             
            Content = str;         
        }                 
        protected override void OnClick()//переопределение OnClick       
        {             
            if (info is FileInfo) //проверка является ли объект info объектом типа FileInfo            
            {                 
                Process.Start(info.FullName);// метод для запуска приложения             
            }             
            else if (info is DirectoryInfo)//если обьект info представляет каталог            
            {                 
                DirectoryInfo dir = info as  DirectoryInfo;//становится каталогом                 
                Application.Current.MainWindow .Title = dir.FullName;// имя каталога отобржается в заголовке окна                 
                Panel pnl = Parent as Panel;                 
                pnl.Children.Clear();                 
                if (dir.Parent != null)//если каталог не корневой                     
                    pnl.Children.Add(new  FileSystemInfoButton(dir.Parent, ".."));// создание кнопки перехода на верхний уровень, если каталог не является корневым              
                foreach (FileSystemInfo inf in dir .GetFileSystemInfos())//содержание каталога                     
                    pnl.Children.Add(new  FileSystemInfoButton(inf));//создание объектов FileSystemInfoButton для всех элементов каталога             
            }             base.OnClick();         
        }     
    } 
} 