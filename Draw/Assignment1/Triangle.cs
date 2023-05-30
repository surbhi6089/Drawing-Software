using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// class to set and draw triangle
    /// it's parent class is abstract class Shapes
    /// </summary>
    public class Triangle : Shapes
    {
        //properties unique to triangle class
        private int x2, y2, x3, y3;
        public Triangle() : base()
        {

        }
        /// <summary>
        /// parameterized constructor that inherits the base parameterized constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public Triangle(Color colour, bool fillShape, int x, int y, int x2, int y2, int x3, int y3) : base(colour, fillShape, x, y)
        {

            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }
        /// <summary>
        /// method to set properties for triangle class
        /// overrides parent method
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        public override void set(Color colour, bool fillShape, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(colour, fillShape, list[0], list[1]);
            this.x2 = list[2];
            this.y2 = list[3];
            this.x3 = list[4];
            this.y3 = list[5];

        }
        /// <summary>
        /// method to draw triangle using properties set by the set method
        /// overrides parent method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            SolidBrush b = new SolidBrush(colour);

            Point p1 = new Point(x, y);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);

            Point[] curvePoints =
            {
                p1,
                p2,
                p3
            };
            if (fillShape)
            {
                g.FillPolygon(b, curvePoints);
            }
            else
            {
                g.DrawPolygon(p, curvePoints);
            }
        }
    }
}
