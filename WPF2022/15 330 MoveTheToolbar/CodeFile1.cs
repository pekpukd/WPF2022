using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.MoveTheToolbar { 
    public class MoveTheToolbar : Window 
    { 
        [STAThread] 
        public static void Main() 
        { 
            Application app = new Application(); 
            app.Run(new MoveTheToolbar()); 
        } 
        public MoveTheToolbar() 
        { 
            Title = "Move the Toolbar";            
            // Создание объекта DockPanel как содержимого окна 
            DockPanel dock = new DockPanel();
            Content = dock;            
            // Создание областей ToolBarTray у левого и верхнего края
            ToolBarTray trayTop = new ToolBarTray();             
            dock.Children.Add(trayTop);             
            DockPanel.SetDock(trayTop, Dock.Top);             
            ToolBarTray trayLeft = new ToolBarTray();             
            trayLeft.Orientation = Orientation .Vertical;             
            dock.Children.Add(trayLeft);             
            DockPanel.SetDock(trayLeft, Dock.Left);             
            // Создание объекта TextBox, заполняющего остальную площадь клиентской области 
            TextBox txtbox = new TextBox();             
            dock.Children.Add(txtbox);             
            // Создание 6 панелей инструментов
            for (int i = 0; i < 6; i++)
                                                                                                                                                                                                                                                         
                 {                 
                ToolBar toolbar = new ToolBar();                 
                toolbar.Header = "Toolbar " + (i + 1);                 
                if (i < 3)                     
                    trayTop.ToolBars.Add(toolbar);                 
                else                     
                    trayLeft.ToolBars.Add(toolbar);                
                // и 6 кнопок на каждой панели
                for (int j = 0; j < 6; j++)                 
                {                     
                    Button btn = new Button();                     
                    btn.FontSize = 16;                     
                    btn.Content = (char)('A' + j);                     
                    toolbar.Items.Add(btn);                 
                }             
            }         
        }     
    } 
} 