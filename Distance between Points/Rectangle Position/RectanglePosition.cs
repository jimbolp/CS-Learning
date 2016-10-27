using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rectangle
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public Rectangle() { }
    public Rectangle(double x, double y, double width, double heigth)
    {
        X = x;
        Y = y;
        Width = width;
        Heigth = heigth;
    }
    public double Width { get; set; }
    public double Heigth { get; set; }
    public double Top
    {
        get
        {
            return Y;
        }
        set { }              
    }
    public double Left
    {
        get
        {
            return X;
        }
        set { }
    }
    public double Bottom
    {
        get
        {
            return Y + Heigth;
        }
        set { }
    }
    public double Right
    {
        get
        {
            return X+Width;
        }
        set { }
    }
    public bool IsInside(Rectangle r)
    {
        if (Top >= r.Top && Left >= r.Left && Right <= r.Right && Bottom <= r.Bottom)
            return true;        
        else
            return false;
    }


}
class Program
{
    static void Main(string[] args)
    {        
        List<Rectangle> rectangles = new List<Rectangle>();
        double[] rect = null;
        for (int i = 0; i < 2; i++)
        {
            rect = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            rectangles.Add(new Rectangle(rect[0], rect[1], rect[2], rect[3]));
        }
        if(rectangles[0].IsInside(rectangles[1]))
            Console.WriteLine("Inside");
        else
            Console.WriteLine("Not Inside");
                
    }
    
}
