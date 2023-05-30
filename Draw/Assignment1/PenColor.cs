using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// class that sets the color of pen
    /// does not extend or implement any other classes
    /// </summary>
    public class PenColor
    {
        private Color color;
        /// <summary>
        /// method to set the color
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            this.color = color;

        }
    }
}
