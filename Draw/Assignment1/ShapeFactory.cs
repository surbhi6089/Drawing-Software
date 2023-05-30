using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// class that implements factory design pattern
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// method that gets the shape type from Form1
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public Shapes GetShape(String shapeType)
        {
            shapeType = shapeType.ToUpper(); 

            if (shapeType.Equals("DRAWTO"))
            {
                return new DrawLine();

            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("TRIANGLE"))
            {
                return new Triangle();
            }
            //throws an appropriate exception if a shape type that is not recognized by the factory is given
            else
            {
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
                throw argEx;
            }
        }
    }
}
