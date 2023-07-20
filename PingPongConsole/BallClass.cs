using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class BallClass
    {

        public PixelPoint BallPosition { get; set; }
        public PixelPoint BallVelocity { get; set; }
        public int TableRows { get; set; }
        public int TableColumns { get; set; }


        /// <summary>
        /// Creates ball and positions it in the middle of the table
        /// </summary>
        /// <param name="color"></param>
        /// <param name="tableRows"></param>
        /// <param name="tableColumns"></param>
        public BallClass(int tableRows, int tableColumns)
        {
            BallPosition = new PixelPoint(tableRows , tableColumns );
            BallVelocity = new PixelPoint(0, -1);
            TableRows = tableRows;
            TableColumns = tableColumns;
        }

        /// <summary>
        /// Update ball movement
        /// </summary>
        public void BallMovement()
        {
            BallPosition += BallVelocity;
        }

    }
}
