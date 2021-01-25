using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece
    {
        string[][] Tablero;
        public Piece(string piece)
        {
            //TODO
            /*
            string[][] Tablero = new string[3][];
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                Tablero[i] = new string[3];
            }


            var rows = piece.Split('\n');*/
        }

        public interface Grid
        {
            int Rows();
            int Columns();
            char CellAt(int row, int col);
        }
    }
}
