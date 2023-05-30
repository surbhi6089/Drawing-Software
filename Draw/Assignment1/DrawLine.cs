using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// class to set and draw line
    /// it's parent class is abstract class Shapes
    /// </summary>
    internal class DrawLine : Shapes
    {
        //properties unique to drawline class
        private int x1;
        private int y1;

        /// <summary>
        /// default constructor that inherits the base constructor
        /// </summary>
        public DrawLine() : base()
        {
            x1 = 100;
            y1 = 150;
        }
        /// <summary>
        /// parameterized constructor that inherits the base parametarized constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public DrawLine(Color colour, bool fillShape, int x, int y, int x1, int y1) : base(colour, fillShape, x, y)
        {

            this.x1 = x1; //the only thingthat is different from shape
            this.y1 = y1;
        }
        /// <summary>
        /// method to set the properties for drawing line
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        public override void set(Color colour, bool fillShape, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(colour, fillShape, list[0], list[1]);
            this.x1 = list[2];
            this.y1 = list[3];
        }
        /// <summary>
        /// method to draw line
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawLine(p, x, y, x1, y1);
        }

    }
}
