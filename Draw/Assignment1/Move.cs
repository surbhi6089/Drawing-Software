using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// class to set the position to move position
    /// </summary>
    internal class Move
    {
        private int x, y;
        /// <summary>
        /// method to set position x-axis and y-axis
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void moveCursor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
