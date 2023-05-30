using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{/// <summary>
/// Abstract class that implements interface I_ShapeInterface
/// </summary>
    public abstract class Shapes : I_ShapeInterface
    {
        public Color colour;
        public int x, y;
        public bool fillShape;

        /// <summary>
        /// default constructor
        /// </summary>
        public Shapes()
        {
            colour = Color.Black;
            x = y = 100;
        }
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillshape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Shapes(Color colour, bool fillshape, int x, int y)
        {
            this.colour = colour;
            this.fillShape = fillshape;
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// abstract method "draw" which can be overridden by it's child classes
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g);
        /// <summary>
        /// abstract method "set" which can be overridden by it's child classes
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        public virtual void set(Color colour, bool fillShape, params int[] list)
        {
            this.colour = colour;
            this.fillShape = fillShape;
            this.x = list[0];
            this.y = list[1];
        }
    }
}
