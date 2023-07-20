using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{

    internal class PlayerClass
    {
        private PixelPoint _playerPosition;
        public PixelPoint PlayerPosition
        {
            get { return _playerPosition;}
            set
            {
                _playerPosition = new PixelPoint(0,0);
                _playerPosition.Row = value.Row-this.Size/2 ;
                _playerPosition.Column = value.Column;
            }
        }

        public int Size
        {
            get;
            set;
        }

        public PlayerClass(int row, int column, int size)
        {
            Size = size;
            PlayerPosition = new PixelPoint(row, column);
        }


        public void MoveUp()
        {
            PlayerPosition.Row--;
        }


        public void MoveDown()
        {
            PlayerPosition.Row++;
        }

    }
}
