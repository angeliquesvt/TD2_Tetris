using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Block
    {
        public char C { get; }
        public int Row { get; set; }
        public int Col { get; set; }
        public Block(char block, int row = 0, int col = 1)
        {
            C = block;
            this.Row = row;
            this.Col = col;
        }

        public Block MoveDown()
        {
            return new Block(this.C, this.Row + 1, this.Col);
        }

        public bool isAt(int row, int col)
        {
            return row == this.Row && col == this.Col;
        }
    }
}
