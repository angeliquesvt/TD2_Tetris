using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class BoardStep1
    {
        readonly int rows;
        readonly int columns;
        private Block fallingBlock;
        private char[,] board;
        private const char EMPTY = '.';

        public BoardStep1(int rows, int columns)
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

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (fallingBlock != null && fallingBlock.isAt(row, col))
                    {
                        s += fallingBlock.C;
                    }
                    else
                        s += board[row, col];
                }
                s += "\n";
            }
            return s;
        }

        public char StatusAt(int row, int col)
        {
            if (fallingBlock != null && fallingBlock.isAt(row, col))
            {
                return fallingBlock.C;
            }
            else
                return board[row, col];
        }

        public bool IsFallingBlock()
        {
            return fallingBlock != null;
        }

        public void Drop(Block block)
        {
            checkIfAlreadyFalling();
            fallingBlock = block;
            //board[0, columns/2] = fallingBlock.C ;
        }

        public void Tick()
        {
            Block test = fallingBlock.MoveDown();
            if (OutsideBoard(test) || HitAnotherBlock(test))
            {
                StopFallingBlock();
            }
            else
            {
                //board[fallingBlock.Row,  fallingBlock.Col] = EMPTY;
                fallingBlock = test;
                //board[fallingBlock.Row, fallingBlock.Col] = fallingBlock.C;
            }
        }

        bool OutsideBoard(Block block)
        {
            return block.Row >= rows;
        }

        public bool HitAnotherBlock(Block block)
        {
            return board[block.Row, block.Col] != EMPTY;
        }

        public void StopFallingBlock()
        {
            board[fallingBlock.Row, fallingBlock.Col] = fallingBlock.C;
            fallingBlock = null;
        }



        void checkIfAlreadyFalling()
        {
            if (IsFallingBlock())
                throw new ArgumentException("A block is already falling.");
        }
    }
}
