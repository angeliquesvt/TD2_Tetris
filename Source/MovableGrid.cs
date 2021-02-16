using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid
    {
        //public char C { get; }
        public int Row { get; set; }
        public int Col { get; set; }
        Tetromino tetromino;

        public MovableGrid(Tetromino tetromino)
        {
            this.Row = 0;
            this.Col = 0;
            this.tetromino = tetromino;
        }

        private MovableGrid(Tetromino tetromino, int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.tetromino = tetromino;
        }

        int ToInnerRow(int outer_row)
        {
            return outer_row - Row;
        }

        int ToOuterRow(int inner_row)
        {
            return Row + inner_row;
        }

        int ToInnerCol(int outer_col)
        {
            return outer_col - Col;
        }

        int ToOuterCol(int inner_col)
        {
            return inner_col + Col;
        }

        public MovableGrid MoveTo(int row, int col)
        {
            return new MovableGrid(tetromino, row, col);
        }

        public MovableGrid MoveDown()
        {
            return new MovableGrid(tetromino, this.Row + 1, this.Col);
        }
        public MovableGrid MoveLeft()
        {
            return new MovableGrid(tetromino, this.Row, this.Col - 1);
        }
        public MovableGrid MoveRight()
        {
            return new MovableGrid(tetromino, this.Row, this.Col + 1);
        }

        public MovableGrid RotateRight()
        {
            return new MovableGrid(tetromino.RotateRight(), this.Row, this.Col);
        }

        public MovableGrid RotateLeft()
        {
            return new MovableGrid(tetromino.RotateLeft(), this.Row, this.Col);
        }


        public bool isAt(int row, int col)
        {
            int inner_row = ToInnerRow(row);
            int inner_col = ToInnerCol(col);
            return inner_row >= 0 
                && inner_row < tetromino.Rows() 
                && inner_col >= 0 
                && inner_col < tetromino.Columns()
                && tetromino.CellAt(inner_row, inner_col) != Board.EMPTY;
        }

        public bool OutsideBoard(Board board)
        {
            for (int r = 0; r < Rows(); r++)
            {
                for (int c = 0; c < Columns(); c++)
                {
                    if (tetromino.CellAt(r,c) != Board.EMPTY)
                    {
                        int row = ToOuterRow(r);
                        int col = ToOuterCol(c);
                        if (col < 0 || col >= board.Cols || row < 0 || row >= board.Rows)
                            return true;
                    }
                }
            }
            return false;
        }

        public bool HitsAnotherBlock(Board board)
        {
            for (int r = 0; r < Rows(); r++)
            {
                for (int c = 0; c < Columns(); c++)
                {
                    if (tetromino.CellAt(r, c) != Board.EMPTY)
                    {
                        int row = ToOuterRow(r);
                        int col = ToOuterCol(c);
                        if (board.CellAt(row, col) != Board.EMPTY)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int Rows()
        {
            return tetromino.Rows();
        }

        public int Columns()
        {
            return tetromino.Columns();
        }

        public char CellAt(int row, int col)
        {
            int inner_row = ToInnerRow(row);
            int inner_col = ToInnerCol(col);
            return tetromino.CellAt(inner_row, inner_col);
        }
    }
}
