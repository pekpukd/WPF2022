using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
/*программа изменяет цвет фона клиентской области в 
зависимости от приближения указателя мыши к центру окна. */
/*При перемещении указателя мыши к центру клиентской области фон 
постепенно светлеет. Если указатель выходит за пределы воображаемого эллипса, 
заполняющего клиентскую область, фон становится черным.
Все содержательные действия выполняются переопределенным методом Оп-
MouseMove, вызываемым при каждом перемещении мыши в клиентской 
области программы. Сначала метод должен вычислить размер клиентской области;
для этого он берет свойства ActualWidth и ActualHeight окна, а затем вычитает из
них размеры рамки и заголовка, полученные из статических свойств класса
SystemParameters.
Координаты указателя мыши получаются вызовом метода GetPosition класса
MouseEventArgs, а полученный объект Point сохраняется в ptMouse. Полученная
точка находится на некотором расстоянии от центра клиентской области —
структуры Point с именем ptCenter. Затем метод вычитает ptCenter из ptMouse.
В документации по структуре Point сказано, что результат вычитания между
двумя объектами Point представляет собой объект типа Vector, сохраняемый этим
методом под именем vectMouse. С математической точки зрения вектор 
определяется длиной и направлением. Длина vectMouse соответствует расстоянию между
ptCenter и ptMouse, а для ее получения используется свойство Length структуры
Vector. Направление вектора определяется свойствами X и Y, представляющими
направление от начала координат (точки (0,0)) в точку (X,Y). В нашем 
конкретном случае значение vectMouse.X равно разности ptMouse.X и ptCenter.X 
(аналогично для Y).
Направление объекта Vector также может быть представлено в виде угла.
Структура Vector содержит статический метод с именем AngleBetween, 
вычисляющий угол между двумя объектами Vector. Метод OnMouseMove в программе 
VaryTheBackground демонстрирует прямое вычисление угла vectMouse через 
арктангенс отношения свойств Y и X. Угол измеряется в радианах по часовой стрелке
от горизонтальной оси. Затем полученный угол используется для вычисления
другого объекта Vector, представляющего расстояние от центра клиентской 
области до точки эллипса, заполняющего клиентскую область. Интенсивность серого
пропорциональна отношению длин двух векторов.
Метод OnMouseMove получает объект Color, связанный с SolidColorBrush, задает
все три цветовые составляющие для формирования оттенка серого, а затем 
задает новое значение свойству Color кисти.*/
namespace Petzold.VaryTheBackground
{ 
    public class VaryTheBackground : Window
    {
        SolidColorBrush brush =new SolidColorBrush(Colors.Black);
        
        public static void Main()
        {
             Application app =new Application();
              app.Run(new VaryTheBackground());
        }
    public VaryTheBackground()
    {
        Title ="Vary the Background";
        Width =384;
        Height =384;
        Background =brush;
    }
    protected override void OnMouseMove(MouseEventArgs args)
    {
        double width =ActualWidth-2 *SystemParameters.ResizeFrameVerticalBorderWidth;
        double height =ActualHeight -2 *SystemParameters.ResizeFrameHorizontalBorderHeight-SystemParameters.CaptionHeight;
        Point ptMouse =args.GetPosition(this);
        Point ptCenter =new Point(width / 2,height / 2);
        Vector vectMouse = ptMouse -ptCenter;
        double angle =Math.Atan2(vectMouse.Y, vectMouse.X);
        Vector vectEllipse =new Vector(width / 2 *Math.Cos(angle), height / 2 *Math.Sin(angle));
        Byte byLevel =(byte)(255 *(1 -Math.Min(1,vectMouse.Length /vectEllipse.Length)));
        Color clr =brush.Color;
        clr.R =clr.G =clr.B =byLevel;
            brush.Color = clr;
    }
}
}

