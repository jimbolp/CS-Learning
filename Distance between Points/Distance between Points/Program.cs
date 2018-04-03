using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_between_Points
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
        public static double Distance(Point  p1, Point p2)
        {
            var a = p1.X - p2.X;
            var b = p1.Y - p2.Y;
            var c2 = a * a + b * b;
            return Math.Sqrt(c2);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var n = int.Parse(Console.ReadLine());
            var points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                var coords = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                points.Add(new Point(coords[0], coords[1]));
            }
            var result = NearestPoints(points);
            Console.WriteLine($"{Point.Distance(result[0], result[1]):f2}{result[0]} {result[1]}");
        }
        public static List<Point> NearestPoints(List<Point> points)
        {
            var nearest = new List<Point>();
            nearest.Add(points[0]);
            nearest.Add(points[1]);
            var distance = Point.Distance(points[0], points[1]);
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i+1; j < points.Count; j++)
                {
                    if (distance > Point.Distance(points[i], points[j]))
                    {
                        distance = Point.Distance(points[i], points[j]);
                        nearest[0] = points[i];
                        nearest[1] = points[j];
                    }                        
                }
            }
            return nearest;
        } 
    }
}
