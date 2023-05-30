using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Child class circle which extends abstract class shapes
    /// </summary>
    public class Circle : Shapes
    {
        //property unique to circle class
        private int radius;
        /// <summary>
        /// default constructor that inherits the base constructor
        /// </summary>
        public Circle() : base()
        {
            radius = 50;
        }
        /// <summary>
        /// parameterized constructor that inherits the base parameterized constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(Color colour, bool fillShape, int x, int y, int radius) : base(colour, fillShape, x, y)
        {
            this.radius = radius; //the only thingthat is different from shape
        }
        /// <summary>
        /// method that overrides the parent method and sets the parameters for shape circle
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        public override void set(Color colour, bool fillShape, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is radius
            base.set(colour, fillShape, list[0], list[1]);
            this.radius = list[2];
        }
        /// <summary>
        /// method that overrides parent method and creates circle with the properties set by "set" method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            SolidBrush b = new SolidBrush(colour);
            if (fillShape)
            {
                g.FillEllipse(b, x, y, radius * 2, radius * 2);
            }
            else
            {
                g.DrawEllipse(p, x, y, radius * 2, radius * 2);
            }
        }

    }
}
