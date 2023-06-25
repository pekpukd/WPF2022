using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SetSpaceProperty
{
    public class SpaceWindow : Window
    {         // DependencyProperty and property.         
        public static readonly DependencyProperty  SpaceProperty;         
        public int Space         
        { 
        set       
            {                 
                SetValue(SpaceProperty, value);
            }
        get    
        {                
                return (int) GetValue(SpaceProperty);
        }
     }         // Static constructor.        
    static SpaceWindow()
    {             // Define metadata.            
        FrameworkPropertyMetadata metadata =  new FrameworkPropertyMetadata();  
        metadata.Inherits = true;
        SpaceProperty.OverrideMetadata(typeof(SpaceWindow), metadata);
    }     
    }
}