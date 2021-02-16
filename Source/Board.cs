using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        int rows;
        int columns;
        private MovableGrid fallingBlock;
        private char[,] board;
        public const char EMPTY = '.';

        public int Rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }

        public int Cols
        {
            get { return this.columns; }
            set { this.columns = value; }
        }

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            board = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    board[row, col] = EMPTY;
                }
            }
        }

        public char CellAt(int row, int col)
        {
            return board[row, col];
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    s += StatusAt(row, col);
                }
                s += "\n";
            }
            return s;
        }

        public void FromString(string blocks)
        {
            StringToMatrix sm = new StringToMatrix(blocks);
            board = sm.blocks;
            Rows = sm.rows;
            Cols = sm.cols;
        }

        public char StatusAt(int row, int col)
        {
            if (fallingBlock != null && fallingBlock.isAt(row, col))
            {
                return fallingBlock.CellAt(row, col);
            }
            else
                return board[row, col];
        }

        public bool IsFallingBlock()
        {
            return fallingBlock != null;
        }

        public void Drop(Tetromino shape)
        {
            checkIfAlreadyFalling();
            int row = StartingRowOffset(shape);
            fallingBlock = new MovableGrid(shape).MoveTo(row, Cols / 2 - shape.Columns() / 2);
        }

        static int StartingRowOffset(Grid shape)
        {
            for (int r = 0; r < shape.Rows(); r++)
            {
                for (int c = 0; c < shape.Columns(); c++)
                {
                    if (shape.CellAt(r, c) != EMPTY) {
                        return -r;
                    }
                }
            }
            return 0;
        }

        static int StartingColOffset(Grid shape)
        {
            for (int c = 0; c < shape.Columns(); c++)
            {
                for (int r = 0; r < shape.Rows(); r++)
                {
                    if (shape.CellAt(r, c) != EMPTY)
                    {
                        return -c;
                    }
                }
            }
            return 0;
        }


        public void Tick()
        {
            MoveDown();
        }

        public void MoveDown()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            MovableGrid test = fallingBlock.MoveDown();
            if (OutsideBoard(test) || HitAnotherBlock(test))
            {
                StopFallingBlock();
                checkFullRows();
            }
            else
            {
                fallingBlock = test;
            }
        }

        public void MoveLeft()
        {
            if (!IsFallingBlock())
                return;
            TryMove(fallingBlock.MoveLeft());
        }

        public void MoveRight()
        {
            if (!IsFallingBlock())
                return;
            TryMove(fallingBlock.MoveRight());
        }

        void TryMove(MovableGrid test)
        {
            if (!(OutsideBoard(test) || HitAnotherBlock(test)))
                fallingBlock = test;
        }

        bool OutsideBoard(MovableGrid block)
        {
            return block.OutsideBoard(this);
        }

        public bool HitAnotherBlock(MovableGrid block)
        {
            return block.HitsAnotherBlock(this);
        }

        void CoptyToBoard(MovableGrid block)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (block.isAt(row, col))
                        board[row, col] = block.CellAt(row, col);
                }
            }
        }

        public void StopFallingBlock()
        {
            CoptyToBoard(fallingBlock);
            fallingBlock = null;
        }

        void checkFullRows() {
            bool rowFull = true;

           
            for (int row = 0; row < Rows; row++)
            {
                if(row == 4)
                {
                    int test = 0;
                }
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == '.') 
                    {
                        rowFull = false;
                    }
                }

                if(rowFull)
                {
                    removeRow(row);
                }
                rowFull = true;
            }
        }

        void removeRow(int indexRowToRemove)
        {
            for(int row = indexRowToRemove; row >= 0; row--)
            {
                for(int col =0; col < Cols; col++)
                {
                    if(row>0)
                    {
                        board[row, col] = board[row - 1, col];
                    }
                    else
                    {
                        board[row, col] = '.';
                    }
                }
            }
        }

        void checkIfAlreadyFalling()
        {
            if(IsFallingBlock())
                throw new ArgumentException("A block is already falling.");
        }

        public void RotateRight()
        {
            TryRotate(fallingBlock.RotateRight());
        }
        public void RotateLeft()
        {
            TryRotate(fallingBlock.RotateLeft());
        }

        void TryRotate(MovableGrid rotated)
        {
            MovableGrid[] moves = { rotated,
            rotated.MoveLeft(),
            rotated.MoveRight(),
            rotated.MoveLeft().MoveLeft(),
            rotated.MoveRight().MoveRight(),};
            foreach (MovableGrid test in moves)
            {
                if (!(OutsideBoard(test) || HitAnotherBlock(test)))
                {
                    fallingBlock = test;
                    return;
                }
            }
        }
    }
}
