using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
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
    class StringToMatrix
    {
        public StringToMatrix(string piece)
        {
            var rows = piece.Split('\n');
            foreach (var col in rows)
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
    }
}
