using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid_Principles
{
    internal class OpenClose
    {
        public OpenClose()
        {
            Console.WriteLine("Open for extension and close for modification");
        }
    }

    //public class AreaCalculator
    //{
    //    public double TotalArea(object obj)
    //    {
    //        if (obj is Rectangle)
    //        {
    //            Rectangle r = (Rectangle)obj;
    //            return r.Height * r.Width;
    //        }
    //        Circle c = (Circle)obj;
    //        return c.Radius * c.Radius * Math.PI;
    //    }
    //}

    public class AreaCalculator
    {
        public double TotalArea(Shape[] obj)
        {
            double area = 0;
            foreach (Shape shape in obj)
            {
                area += shape.Area();
            }

            return area;
        }
    }

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return 2 * Radius * Math.PI;
        }
    }
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return (Base * Height) / 2;
        }
    }
}
