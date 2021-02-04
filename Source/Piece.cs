using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        char[,] blocks;
        int rows, cols;

        public Piece(string piece)
        {
            StringToMatrix s_m = new StringToMatrix(piece);
            blocks = s_m.blocks;
            rows = s_m.rows;
            cols = s_m.cols;
        }

        public char CellAt(int row, int col)
        {
            return blocks[row,  col];
        }

        public int Columns()
        {
            return cols;
        }

        public int Rows()
        {
            return rows;
        }
    }
}
