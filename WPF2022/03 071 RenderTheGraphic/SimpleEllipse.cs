//---------------------------------------------- 
// SimpleEllipse.cs (c) 2006 by Charles Petzold 
//---------------------------------------------- 
using System;
using System.Windows;
using System.Windows.Media;
namespace Petzold.RenderTheGraphic
{
    class SimpleEllipse : FrameworkElement     //класс является производным от FrameworkElement
    {
        protected override void OnRender(DrawingContext dc)    //переопределяет метод OnRender для получения DrawingContext
        {
            dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 24),  //DrawingContext используется для рисования эллипса методом DrawEllipse              
            new Point(RenderSize.Width / 2, RenderSize.Height / 2),
            RenderSize.Width / 2, RenderSize.Height / 2);
        }
    }
}

