using System;

namespace FacadeShape
{
    class FacadePatternDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.drawCircle();
            shapeMaker.drawRectangle();
            shapeMaker.drawSquare();
        }
    }


    public interface Shape
    {
        void draw();
    }
    public class Circle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Circle::draw() drawing circle");
        }
    }
    public class Rectangle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Rectangle::draw() drawing rectangle");
        }
    }
    public class Square : Shape
    {
        public void draw()
        {
            Console.WriteLine("Square::draw() drawing square");
        }
    }

    public class ShapeMaker
    {
        private Shape circle;
        private Shape rectangle;
        private Shape square;

        public ShapeMaker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }

        public void drawCircle()
        {
            circle.draw();
        }
        public void drawRectangle()
        {
            rectangle.draw();
        }
        public void drawSquare()
        {
            square.draw();
        }
    }
}
