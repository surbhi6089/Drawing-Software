using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Class to set and draw rectangle shape
    /// it's parent class is abstract class Shapes
    /// </summary>
    public class Rectangle : Shapes
    {
        //properties unique to rectangle class
        private int width, height;
        /// <summary>
        /// default constructor that inherits the base constructor
        /// </summary>
        public Rectangle() : base()
        {
            width = 100;
            height = 100;
        }
        /// <summary>
        /// parameterized constructor that inherits the base parameterized constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(Color colour, bool fillShape, int x, int y, int width, int height) : base(colour, fillShape, x, y)
        {

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// method to set properties for shape rectangle
        /// overrides parent method
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        public override void set(Color colour, bool fillShape, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(colour, fillShape, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }
        /// <summary>
        /// method to draw shape rectangle using properties set by the set method
        /// overrides parent method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            SolidBrush b = new SolidBrush(colour);
            if (fillShape)
            {
                g.FillRectangle(b, x, y, width, height);
            }
            else
            {
                g.DrawRectangle(p, x, y, width, height);
            }
        }

    }
}
