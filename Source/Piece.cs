using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        char[,] Tablero;
        int rows;
        int cols;

        //string grid = "...\n...\n...\n";

        //StringToMatrix converter = new StringToMatrix(grid);

        /*CollectionAssert.AreEqual(converter.blocks, new char[,] {
            {'.','.','.'},
            {'.','.','.'},
            {'.','.','.'}
        });*/
        /*
         * rows = piece.Split('\n');
         * => {'...','...','...'}
         * */
        public Piece(string piece)
        {
            var rows = piece.Split('\n');
            foreach(var col in rows)
            {
                var c = col.ToCharArray();
            }
            //TODO
            /*
            string[][] Tablero = new string[3][];
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                Tablero[i] = new string[3];
            }

            
            var rows = piece.Split('\n');
            rows.ToCharArray();*/
    }

    public char CellAt(int row, int col)
        {
            throw new NotImplementedException();
        }

        public int Columns()
        {
            throw new NotImplementedException();
        }

        public int Rows()
        {
            return Tablero.Length;
        }
    }
}
