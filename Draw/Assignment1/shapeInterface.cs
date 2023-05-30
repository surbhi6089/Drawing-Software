using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{/// <summary>
/// This is an interface which is implemented by the abstract class Shapes
/// </summary>
    public interface I_ShapeInterface
    {
        /// <summary>
        /// abstract method to set the properties of the shapes
        /// </summary>
        /// <param name="c"></param>
        /// <param name="fillShape"></param>
        /// <param name="list"></param>
        void set(Color c, bool fillShape, params int[] list);
        /// <summary>
        /// abstract method to draw the shape 
        /// </summary>
        /// <param name="g"></param>
        void draw(Graphics g);
    }
}
