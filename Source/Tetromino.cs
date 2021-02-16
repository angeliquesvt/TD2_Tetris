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

        public override String ToString()
        {
            return all_orientations[current_orientation].ToString();
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
                "IIII\n" +
                "....\n" +
                "....\n"
            ,
                "..I.\n" +
                "..I.\n" +
                "..I.\n" +
                "..I.\n"
            );

        static public readonly Tetromino L_SHAPE = new Tetromino(
         "....\n" +
         "....\n" +
         "...J\n" +
         "JJJJ\n"
     ,
         "J...\n" +
         "J...\n" +
         "j...\n" +
         "JJ..\n"
     ,
         "....\n" +
         "....\n" +
         "JJJJ\n" +
         "J...\n"
     ,
         "..JJ\n" +
         "...J\n" +
         "...J\n" +
         "...j\n"
     );

        static public readonly Tetromino J_SHAPE = new Tetromino(
         "....\n" +
         "....\n" +
         "J...\n" +
         "JJJJ\n"
        ,
         "JJ..\n" +
         "J...\n" +
         "J...\n" +
         "J...\n"
        ,
         "....\n" +
         "....\n" +
         "JJJJ\n" +
         "...J\n"
        ,
         "...J\n" +
         "...J\n" +
         "...J\n" +
         "..JJ\n"
        );

        static public readonly Tetromino O_SHAPE = new Tetromino(
         "....\n" +
         ".OO.\n" +
         ".OO.\n" +
         "....\n"
        );

        static public readonly Tetromino S_SHAPE = new Tetromino(
         "....\n" +
         "....\n" +
         ".SS.\n" +
         "SS..\n"
        ,
         "....\n" +
         "S...\n" +
         "SS..\n" +
         ".S..\n"
        );


        static public readonly Tetromino Z_SHAPE = new Tetromino(
         "....\n" +
         "....\n" +
         "ZZ..\n" +
         ".ZZ.\n"
        ,
         "....\n" +
         ".Z..\n" +
         "ZZ..\n" +
         "Z...\n"
        );

    }
}
