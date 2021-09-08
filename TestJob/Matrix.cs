using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    public class Matrix : IMatrix
    {
        public int M { get; set; }
        public MatrixElement[,] elements { get; set; }

        public void AutoFill()
        {
            MatrixElement[,] matrix = new MatrixElement[M, M];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = new MatrixElement
                    {
                        Value = new Random().Next(0, 9)
                    };
                }
            }
            this.elements = matrix;
        }
        public MatrixElement[,] FillNewMatrix(Matrix matrix)
        {
            MatrixElement[,] newMatrix = new MatrixElement[matrix.M, matrix.M];
            for (int i = 0; i < matrix.M; i++)
            {
                for (int j = 0; j < matrix.M; j++)
                {
                    int inRow = FindInRow(matrix.elements, matrix.elements[i, j].Value, i);
                    int inCol = FindInColumn(matrix.elements, matrix.elements[i, j].Value, j);
                    newMatrix[i, j] = new MatrixElement();

                    if (inRow == 1 && inCol == 1)
                    {
                        newMatrix[i, j] = new MatrixElement(matrix.elements[i, j].Value);
                    }
                    else if (inRow > 1 && inCol == 1)
                    {
                        newMatrix[i, j] = new MatrixElement(matrix.elements[i, j].Value * inRow)
                        {
                            Marker = "Yellow"
                        };
                    }
                    else if (inRow == 1 && inCol > 1)
                    {
                        newMatrix[i, j] = new MatrixElement(matrix.elements[i, j].Value * inCol)
                        {
                            Marker = "Green"
                        };
                    }
                    else if (inRow > 1 && inCol > 1)
                    {
                        newMatrix[i, j] = new MatrixElement(matrix.elements[i, j].Value * inCol + matrix.elements[i, j].Value * inRow)
                        {
                            Marker = "Blue"
                        };
                    }
                }
            }
            return newMatrix;
        }
        private int FindInRow(MatrixElement[,] matrix, int comparable, int iRow)
        {
            int count = 0;
            for (int i = 0; i < M; i++)
            {
                if (matrix[iRow, i].Value == comparable) count++;
            }
            return count;
        }
        public int FindInColumn(MatrixElement[,] matrix, int comparable, int iCol)
        {
            int count = 0;
            for (int i = 0; i < M; i++)
            {
                if (matrix[i, iCol].Value == comparable) count++;
            }
            return count;
        }

        public Matrix(int size)
        {
            this.M = size;
            this.elements = new MatrixElement[M, M];
            for (int i = 0; i < this.M; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    this.elements[i, j] = new MatrixElement(0);
                }
            }
        }
    }
}
