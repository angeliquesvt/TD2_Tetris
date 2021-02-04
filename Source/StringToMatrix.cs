using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source {
    public class StringToMatrix
    {
        public char[,] blocks;
        public int rows, cols;

        public StringToMatrix(string stringToConvert)
        {
            string[] lines = stringToConvert.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            rows = lines.Length;
            cols = lines[0].Length;

            blocks = new char[rows,  cols];

            for(int i = 0; i < rows; i++)
            {
                char[] line = lines[i].ToCharArray();

                if (line.Length != cols)
                    throw new Exception("All rows should be same size");
                for  (int j = 0; j < cols; j++)
                    blocks[i,  j] = line[j];
            }

        }

        static public string Inverse(char[,] matrix, int rows, int cols)
        {
            string stringMatrix = "";
            for(int col = 0; col<cols; col++) 
            {
                for(int row = 0; row<rows; row++)
                {
                    stringMatrix += matrix[col,row];
                }
                stringMatrix += "\n";
            }

            return stringMatrix;
        }
    }
}
