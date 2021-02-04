using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid
    {
        public char C { get; }
        public int Row { get; set; }
        public int Col { get; set; }
        Tetromino tetromino;

        private MovableGrid(int col, int row, Tetromino tetromino)
        {
            this.Row = col;
            this.Col = row;
            this.tetromino = tetromino;
        }

        public Block MoveDown()
        {
            return new Block(this.C, this.Row + 1, this.Col);
        }

        public bool isAt(int row, int col)
        {
            return row == this.Row && col == this.Col;
        }

        public int Rows()
        {
            return this.Row;
        }

        public int Columns()
        {
            return this.Col;
        }

        public char CellAt(int row, int col)
        {
            return C;
        }
    }
}
