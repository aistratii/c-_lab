using ConsoleApp1.lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLab.ConsoleApp1.lab2 {

    class Determinant {
        private CompoundNumber value;
        private int sign = +1;

        public CompoundNumber getValue() {
            return new CompoundNumber(sign) * value;
        }

        //TODO FIX 3+ level matrix
        public Determinant(CompoundNumber[,] matrix, int excludeRow, int excludeColumn) {
            CompoundNumber[,] newMatrix = new CompoundNumber[matrix.GetUpperBound(0), matrix.GetUpperBound(1)];

            CompoundNumber[,] tmpMatrix = new CompoundNumber[matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1) + 1];
            //copy
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                    tmpMatrix[i, j] = matrix[i, j];

            //displace rows
            for (int i = excludeRow; i < tmpMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= tmpMatrix.GetUpperBound(1); j++)
                    tmpMatrix[i, j] = tmpMatrix[i + 1, j];

            //displace columns
            for (int i = 0; i <= tmpMatrix.GetUpperBound(0); i++)
                for (int j = excludeColumn; j < tmpMatrix.GetUpperBound(1); j++)
                    tmpMatrix[i, j] = tmpMatrix[i, j + 1];

            //copy displaced data
            for (int i = 0; i < tmpMatrix.GetUpperBound(0); i++)
                for (int j = 0; j < tmpMatrix.GetUpperBound(1); j++)
                    newMatrix[i, j] = tmpMatrix[i, j];


            //[+] -
            //- + 
            if (excludeRow % 2 == 0 && excludeColumn % 2 == 0)
                this.sign = +1;

            //+ [-]
            //- + 
            else if (excludeRow % 2 == 0 && excludeColumn % 2 != 0)
                this.sign = -1;

            //+ -
            //[-] + 
            else if (excludeRow % 2 != 0 && excludeColumn % 2 == 0)
                this.sign = -1;

            //+ -
            //- [+] 
            else if (excludeRow % 2 != 0 && excludeColumn % 2 != 0)
                this.sign = +1;


            initiateThis(newMatrix);
        }

        public Determinant(CompoundNumber[,] matrix) {
            initiateThis(matrix);
        }


        private void initiateThis(CompoundNumber[,] matrix) {
            if (matrix.GetUpperBound(0) > 2 || matrix.GetUpperBound(1) > 2) {
                calculateRecursievly(matrix);
            } else {
                calculateNonReursievly(matrix);
            }
        }

        private void calculateRecursievly(CompoundNumber[,] matrix) {
            Tuple<int, int> rowAndColumn = choseRowAndColumn(matrix);

            if (rowAndColumn.Item1 != -1 && rowAndColumn.Item2 == -1) {
                this.value = calculateDeterminantByRow(matrix, rowAndColumn.Item1);
            } else if (rowAndColumn.Item1 == -1 && rowAndColumn.Item2 != -1) {
                this.value = calculateDeterminantByColumn(matrix, rowAndColumn.Item1);
            } else {
                throw new Exception("Could not choose wheter to pick line or column");
            }
        }

        private void calculateNonReursievly(CompoundNumber[,] matrix) {
            if (matrix.GetUpperBound(0) == matrix.GetUpperBound(1)) {
                if (matrix.GetUpperBound(0) == 0)
                    this.value = matrix[0, 0];
                else if (matrix.GetUpperBound(0) == 1)
                    this.value = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
                else if (matrix.GetUpperBound(0) == 2) {
                    CompoundNumber main = matrix[0, 0] * matrix[1, 1] * matrix[2, 2]
                                + matrix[0, 1] * matrix[1, 2] * matrix[2, 0]
                                + matrix[0, 2] * matrix[1, 0] * matrix[2, 1];

                    CompoundNumber secondary = matrix[2, 0] * matrix[1, 1] * matrix[0, 2]
                                + matrix[2, 1] * matrix[1, 2] * matrix[0, 0]
                                + matrix[2, 2] * matrix[1, 0] * matrix[0, 1];

                    this.value = main - secondary;
                }

                //(0, 0) | (0, 1) | (0, 2)
                //(1, 0) | (1, 1) | (1, 2)
                //(2, 0) | (2, 1) | (2, 2)
            } else {
                throw new Exception("Rows and columns' number don't match");
            }
        }

        private CompoundNumber calculateDeterminantByColumn(CompoundNumber[,] matrix, int column) {
            List<CompoundNumber> determinantLists = new List<CompoundNumber>();

            for (int i = 0; i < matrix.GetUpperBound(1); i++) {
                determinantLists.Add(new Determinant(matrix, i, column).getValue());
            }


            CompoundNumber result = determinantLists[0];
            for (int i = 1; i < determinantLists.Count(); i++) {
                result = result + determinantLists[i];
            }

            return result;
        }

        private CompoundNumber calculateDeterminantByRow(CompoundNumber[,] matrix, int row) {
            List<CompoundNumber> determinantLists = new List<CompoundNumber>();

            for (int i = 0; i < matrix.GetUpperBound(0); i++) {
                determinantLists.Add(new Determinant(matrix, row, i).getValue());
            }

            CompoundNumber result = determinantLists[0];
            for (int i = 1; i < determinantLists.Count(); i++) {
                result = result + determinantLists[i];
            }

            return result;
        }


        //TODO: Make it select the row or column with the most "0"
        private Tuple<int, int> choseRowAndColumn(CompoundNumber[,] matrix) {
            return Tuple.Create(0, -1);
        }
    }
}
