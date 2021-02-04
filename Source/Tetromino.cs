using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {
        private List<Piece> all_orientations;
        private int current_orientation;
        public Tetromino(params string[] pieces)
        {
            all_orientations = new List<Piece>();
            for (int i = 0; i < pieces.Length; i++)
                all_orientations.Add(new Piece(pieces[i]));
            this.current_orientation = 0;
        }

        public bool isAt(int row, int col)
        {
            return row == Rows() && col == Columns();
        }

        public Piece Current()
        {
            return this.all_orientations[this.current_orientation];
        }

        private Tetromino(List<Piece> all_orientations, int current_or)
        {
            this.all_orientations = all_orientations;
            this.current_orientation = (current_or + all_orientations.Count) % all_orientations.Count;
        }

        public override string ToString()
        {
            return this.all_orientations[this.current_orientation].ToString();
        }

        public Tetromino RotateRight()
        {
            return new Tetromino(this.all_orientations, current_orientation + 1);
        }

        public Tetromino RotateLeft()
        {
            return new Tetromino(this.all_orientations, current_orientation - 1);
        }

        public char CellAt(int row, int col)
        {
            return this.all_orientations[this.current_orientation].CellAt(row, col);
        }

        public int Columns()
        {
            return this.all_orientations[this.current_orientation].Columns();
        }

        public int Rows()
        {
            return this.all_orientations[this.current_orientation].Rows();
        }

        static public readonly Tetromino T_SHAPE = new Tetromino(
                "....\n" +
                "TTT.\n" +
                ".T..\n"
            ,
                ".T..\n" +
                "TT..\n" +
                ".T..\n"
            ,
                "....\n" +
                ".T..\n" +
                "TTT.\n"
            ,
                ".T..\n" +
                ".TT.\n" +
                ".T..\n"
            );

        static public readonly Tetromino I_SHAPE = new Tetromino(
                "....\n" +
                "TTTT\n" +
                "....\n" +
                "....\n"
            ,
                "..T.\n" +
                "..T.\n" +
                "..T.\n" +
                "..T.\n"
            );

    }
}
