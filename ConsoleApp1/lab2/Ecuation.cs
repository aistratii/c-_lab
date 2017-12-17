using CLab.ConsoleApp1.lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.lab2 {
    class Ecuation<T> {

        private Matrix<CustomType<T>> ecuation, result;

        public Ecuation(Matrix<CustomType<T>> ecuation) {
            this.ecuation = ecuation;
        }


        public void solve() {
            Matrix<CustomType<T>> matrixA = getMatrixA();
            Matrix<CustomType<T>> matrixB = getMatrixB();

            Matrix<CustomType<T>> invertedA = invertMatrix(matrixA);
            Matrix<CustomType<T>> adjunctMatrixA = adjunctMatrix(invertedA);

            Matrix<CustomType<T>> determinantOfA = new Determinant(matrixA).getValue();

            Matrix<CustomType<T>> matrixX = getMatrixX(determinantOfA, adjunctMatrixA, matrixB);

            this.result = matrixX;
        }

        private CompoundNumber[,] getMatrixX(CompoundNumber determinant, CompoundNumber[,] adjunctMatrixA, CompoundNumber[,] matrixB) {
            CompoundNumber[,] tempMatrix = multiplyMatrixes(adjunctMatrixA, matrixB);

            for (int i = 0; i <= matrixB.GetUpperBound(0); i++)
                tempMatrix[i, 0] = (new CompoundNumber(1) / determinant) * tempMatrix[i, 0];

            return tempMatrix;
        }

        private CompoundNumber[,] adjunctMatrix(CompoundNumber[,] matrix) {
            CompoundNumber[,] adjunctMatrix = new CompoundNumber[matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1) + 1];

            for (int i = 0; i <= adjunctMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= adjunctMatrix.GetUpperBound(0); j++)
                    adjunctMatrix[i, j] = new Determinant(matrix, i, j).getValue();

            return adjunctMatrix;
        }


        private Matrix<CustomType<T>> multiplyNumberToMatrix(CustomType<T> coefecient, Matrix<CustomType<T>> matrix) {
            Matrix<CustomType<T>> multipliedMatrix = (Matrix<CustomType<T>>)matrix.Clone();

            for (int i = 0; i <= multipliedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= multipliedMatrix.GetUpperBound(1); j++)
                    matrix[i, j] = coefecient * matrix[i, j];

            return multipliedMatrix;
        }

        private Matrix<CustomType<T>> multiplyMatrixes(Matrix<CustomType<T>> first, Matrix<CustomType<T>> second) {
            CustomType<T>[,] multiplied = new CustomType<T>[first.getDimension(0) +1, second.getDimension(1) + 1];

            for (int i = 0; i <= multiplied.GetUpperBound(0); i++)
                for (int j = 0; j <= multiplied.GetUpperBound(1); j++) {
                    CustomType<T>[] vector1 = new CustomType<T>[first.getDimension(1) + 1];
                    CustomType<T>[] vector2 = new CustomType<T>[second.getDimension(0) + 1];
                    CustomType<T>[] dotResultVector = new CustomType<T>[vector1.Length];


                    for (int vi = 0; vi < vector1.Length; vi++)
                        vector1[vi] = first.elem(i, vi);

                    for (int vi = 0; vi < vector2.Length; vi++)
                        vector2[vi] = second.elem(vi, j);

                    for (int vi = 0; vi < dotResultVector.Length; vi++)
                        dotResultVector[vi] = vector1[vi] * vector2[vi];

                    CustomType<T> dotResult = dotResultVector[0];
                    for (int vi = 1; vi < dotResultVector.Length; vi++)
                        dotResult = dotResult + dotResultVector[vi];

                    multiplied[i, j] = dotResult;
                }
                    

            return new Matrix<CustomType<T>>(multiplied);
        }

        private Matrix<CustomType<T>> invertMatrix(Matrix<CustomType<T>> matrix) {
            CustomType<T>[,] invertedMatrix = new CustomType<T>[matrix.getDimension(0) +1, matrix.getDimension(1) + 1];

            for (int i = 0; i <= matrix.getDimension(0); i++)
                for (int j = 0; j <= matrix.getDimension(1); j++)
                    invertedMatrix[j, i] = matrix.elem(i, j);

            return new Matrix<CustomType<T>>(invertedMatrix);
        }

        private Matrix<CustomType<T>> getMatrixB() {
            CustomType<T>[,] matrixB = new CustomType<T>[ecuation.getDimension(0) + 1, 1];

            for (int i = 0; i <= ecuation.getDimension(0); i++)
                matrixB[i, 0] = ecuation.elem(i, ecuation.getDimension(1));

            return new Matrix<CustomType<T>>(matrixB);
        }

        private Matrix<CustomType<T>> getMatrixA() {
            CustomType<T>[,] matrixA = new CustomType<T>[ecuation.getDimension(0) + 1, ecuation.getDimension(1)];

            for (int i = 0; i <= ecuation.getDimension(0); i++)
                for (int j = 0; j < ecuation.getDimension(1); j++)
                    matrixA[i, j] = ecuation.elem(i, j);

            return new Matrix<CustomType<T>>(matrixA);
        }

        internal void prettyPrint() {
            Console.WriteLine("rezultatele: ");

            for (int i = 0; i <= result.getDimension(0); i++)
                Console.WriteLine("Necunoscuta {0} este {1}", i, result.elem(i, 0));

            for (int i = 0; i <= ecuation.getDimension(0); i++) {
                for (int j = 0; j <= ecuation.getDimension(1); j++) {
                    string constant = ecuation.elem(i, j).ToString();
                    //(j != 0 && ecuation.elem(i, j).isNonNegative() ? "+" : "") + ecuation.elem(i, j).ToString();

                    string unkown = result.elem(j, 0).ToString(); // result[j, 0].isNonNegative()
                        //? result[j, 0].ToString()
                        //: "(" + result[j, 0] + ")";

                    Console.Write("{0}*{1} ", constant, unkown);
                }
                Console.Write(" = {0}", ecuation.elem(i, ecuation.getDimension(1)));
                Console.WriteLine();
            }
        }
    }
}
