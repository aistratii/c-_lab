using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLab.ConsoleApp1.lab2 {
    class Matrix<T> {
        private T[,] matrix;

        public Matrix(T[,] matrix) {
            this.matrix = matrix;
        }

        public int getDimension(int dim) {
            return matrix.GetUpperBound(dim);
        }

        public T elem(int i, int j) {
            return matrix[i, j];
        }
    }
}
