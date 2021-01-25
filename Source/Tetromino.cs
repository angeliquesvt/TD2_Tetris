using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino
    {
        private List<string> all_orientations;
        //first_orientation, second_orientation, third_orientation, fourth_orientation;
        private int current_orientation;
        private int nb_orientation_possible;
        public Tetromino(string var1, string var2 = "", string var3 = "", string var4 = "", int current_or = 0)
        {
            this.nb_orientation_possible = 1;
            all_orientations = new List<string>();
            all_orientations.Add(var1);
            all_orientations.Add(var2);
            all_orientations.Add(var3);
            all_orientations.Add(var4);
            if (var2.Length != 0)
                nb_orientation_possible++;
            if (var3.Length != 0)
                nb_orientation_possible++;
            if (var4.Length != 0)
                nb_orientation_possible++;
            this.current_orientation = current_or;
        }

        public override string ToString()
        {
            return this.all_orientations[this.current_orientation];
        }

        public Tetromino RotateRight()
        {
            int next_orientation = (current_orientation + 1) % this.nb_orientation_possible;
            Tetromino right_r = new Tetromino(this.all_orientations[0], this.all_orientations[1], this.all_orientations[2], this.all_orientations[3], next_orientation);
            return right_r;
        }

        public Tetromino RotateLeft()
        {
            int next_orientation = 0;
            if (this.current_orientation == 0)
                next_orientation = this.nb_orientation_possible-1;
            else
                next_orientation = this.current_orientation - 1;
            Tetromino left_r = new Tetromino(this.all_orientations[0], this.all_orientations[1], this.all_orientations[2], this.all_orientations[3], next_orientation);
            return left_r;
        }
    }
}
