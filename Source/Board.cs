using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        readonly int rows;
        readonly int columns;
        private bool fallingblock = false;
        private char[,] board;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            board = new char[rows, columns];
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if(board[row, col] == '\0')
                    {
                        s += ".";
                    }
                        
                }
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock()
        {      
            return fallingblock;
        }
        
        public void Drop(Block block)
        {
            fallingblock = true;
            
        }
    } 
}
