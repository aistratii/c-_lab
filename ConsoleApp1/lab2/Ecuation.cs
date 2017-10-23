using CLab.ConsoleApp1.lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.lab2 {
    class Ecuation {

        private CompoundNumber[,] ecuation, result;

        public Ecuation() {
        }


        public void solve() {
            CompoundNumber[,] matrixA = getMatrixA();
            CompoundNumber[,] matrixB = getMatrixB();

            CompoundNumber[,] invertedA = invertMatrix(matrixA);
            CompoundNumber[,] adjunctMatrixA = adjunctMatrix(invertedA);

            CompoundNumber determinantOfA = new Determinant(matrixA).getValue();

            CompoundNumber[,] matrixX = getMatrixX(determinantOfA, adjunctMatrixA, matrixB);

            this.result = matrixX;

            //CompoundNumber[,] multiplied = multiplyMatrixes(coefecientInvertedMatrixA.Item2, matrixB);

            //CompoundNumber[,] unkwons = multiplyNumberToMatrix(coefecientInvertedMatrixA.Item1, multiplied);
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


        private CompoundNumber[,] multiplyNumberToMatrix(CompoundNumber coefecient, CompoundNumber[,] matrix) {
            CompoundNumber[,] multipliedMatrix = (CompoundNumber[,])matrix.Clone();

            for (int i = 0; i <= multipliedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= multipliedMatrix.GetUpperBound(1); j++)
                    matrix[i, j] = coefecient * matrix[i, j];

            return multipliedMatrix;
        }

        private CompoundNumber[,] multiplyMatrixes(CompoundNumber[,] first, CompoundNumber[,] second) {
            CompoundNumber[,] multiplied = new CompoundNumber[first.GetUpperBound(0) +1, second.GetUpperBound(1) + 1];

            for (int i = 0; i <= multiplied.GetUpperBound(0); i++)
                for (int j = 0; j <= multiplied.GetUpperBound(1); j++) {
                    CompoundNumber[] vector1 = new CompoundNumber[first.GetUpperBound(1) + 1];
                    CompoundNumber[] vector2 = new CompoundNumber[second.GetUpperBound(0) + 1];
                    CompoundNumber[] dotResultVector = new CompoundNumber[vector1.Length];


                    for (int vi = 0; vi < vector1.Length; vi++)
                        vector1[vi] = first[i, vi];

                    for (int vi = 0; vi < vector2.Length; vi++)
                        vector2[vi] = second[vi, j];

                    for (int vi = 0; vi < dotResultVector.Length; vi++)
                        dotResultVector[vi] = vector1[vi] * vector2[vi];

                    CompoundNumber dotResult = new CompoundNumber(0);
                    for (int vi = 0; vi < dotResultVector.Length; vi++)
                        dotResult = dotResult + dotResultVector[vi];

                    multiplied[i, j] = dotResult;
                }
                    

            return multiplied;
        }

        private CompoundNumber[,] invertMatrix(CompoundNumber[,] matrix) {
            CompoundNumber[,] invertedMatrix = new CompoundNumber[matrix.GetUpperBound(0) +1, matrix.GetUpperBound(1) + 1];

            CompoundNumber determinant = new CompoundNumber(1) / new Determinant(matrix).getValue();

            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                    invertedMatrix[j, i] = matrix[i, j];

            return invertedMatrix;
        }

        private CompoundNumber[,] getMatrixB() {
            CompoundNumber[,] matrixB = new CompoundNumber[ecuation.GetUpperBound(0) + 1, 1];

            for (int i = 0; i <= ecuation.GetUpperBound(0); i++)
                matrixB[i, 0] = ecuation[i, ecuation.GetUpperBound(1)];

            return matrixB;
        }

        private CompoundNumber[,] getMatrixA() {
            CompoundNumber[,] matrixA = new CompoundNumber[ecuation.GetUpperBound(0) + 1, ecuation.GetUpperBound(1)];

            for (int i = 0; i <= ecuation.GetUpperBound(0); i++)
                for (int j = 0; j < ecuation.GetUpperBound(1); j++)
                    matrixA[i, j] = ecuation[i, j];

            return matrixA;
        }

        //(known number, unknown number x)
        internal void setEcuation(CompoundNumber[,] ecuationArray) {
            this.ecuation = ecuationArray;
        }

        internal void prettyPrint() {
            Console.WriteLine("rezultatele: ");

            for (int i = 0; i <= result.GetUpperBound(0); i++)
                Console.WriteLine("Necunoscuta {0} este {1}", i, result[i, 0]);

            for (int i = 0; i <= ecuation.GetUpperBound(0); i++) {
                for (int j = 0; j < ecuation.GetUpperBound(1); j++) {
                    string constant = (j != 0 && ecuation[i, j].isNonNegative() ? "+" : "") + ecuation[i, j].ToString();

                    string unkown = result[j, 0].isNonNegative()
                        ? result[j, 0].ToString()
                        : "(" + result[j, 0] + ")";

                    Console.Write("{0}*{1} ", constant, unkown);
                }
                Console.Write(" = {0}", ecuation[i, ecuation.GetUpperBound(1)]);
                Console.WriteLine();
            }
        }
    }
}
