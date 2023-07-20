using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class PixelPoint
    {

        private int _row;
        private int _column;

        public int Row
        {
            get { return _row;}
            set
            {
                _row = value;
            }
        }

        public int Column
        {
            get { return _column; }
            set
            {
                _column = value;
            }
        }

        /// <summary>
        /// Create ball 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public PixelPoint(int row, int column)
        {
            Row = row;
            Column = column;
        }


        public static PixelPoint operator + (PixelPoint p1, PixelPoint p2)
        {
            return new PixelPoint(p1.Row + p2.Row, p1.Column + p2.Column);
        }

    }
}
