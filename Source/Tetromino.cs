using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {
        private List<string> all_orientations;
        private int current_orientation;

        public Tetromino(string var1, string var2 = "", string var3 = "", string var4 = "", int current_or = 0)
        {
            all_orientations = new List<string>();
            all_orientations.Add(var1);
            if (var2.Length != 0)
                all_orientations.Add(var2);
            if (var3.Length != 0)
                all_orientations.Add(var3);
            if (var4.Length != 0)
                all_orientations.Add(var4);
            this.current_orientation = current_or;
        }

        private Tetromino(List<string> all_orientations, int current_or)
        {
            this.all_orientations = all_orientations;
            this.current_orientation = current_or;
            //TODO ? Faire le modulo ici
        }

        public override string ToString()
        {
            return this.all_orientations[this.current_orientation];
        }

        public Tetromino RotateRight()
        {
            int next_orientation = (current_orientation + 1) % this.all_orientations.Count;
            Tetromino right_r = new Tetromino(this.all_orientations, next_orientation);
            return right_r;
        }

        public Tetromino RotateLeft()
        {
            int next_orientation = 0;
            if (this.current_orientation == 0)
                next_orientation = this.all_orientations.Count - 1;
            else
                next_orientation = this.current_orientation - 1;
            Tetromino left_r = new Tetromino(this.all_orientations, next_orientation);
            return left_r;
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
            throw new NotImplementedException();
        }
    }
}
