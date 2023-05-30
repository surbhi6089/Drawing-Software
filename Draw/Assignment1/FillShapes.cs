using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment1
{
    /// <summary>
    /// class to set the fill mode on or off
    /// does not have a parent class
    /// </summary>
    internal class FillShapes
    {
        private bool fillShape;
        /// <summary>
        /// method to set the fill mode on or off
        /// </summary>
        /// <param name="fillShape"></param>
        public void fillColour(bool fillShape)
        {
            this.fillShape = fillShape;
        }
    }
}
