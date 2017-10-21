using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1.algorythm.sorting.animation {
    class AnimateSwitching : Animation {

        public AnimateSwitching(float refreshRate) : base(refreshRate) {}

        public override void animate(int[] array, string message, int leftIndex, int rightIndex, State state) {
            string finalMessage = !string.IsNullOrEmpty(message) ? message : convertStateToMessage(state, leftIndex, rightIndex);
            
            dispayAllArray(array, finalMessage, leftIndex, rightIndex, state);
            Thread.Sleep((int)(refreshRate * 1));

            liftUp(array, finalMessage, leftIndex, rightIndex, state);
            Thread.Sleep((int)(refreshRate * 1));

            switchWithplaces(array, finalMessage, leftIndex, rightIndex, state);
            Thread.Sleep((int)(refreshRate * 1));

            lowerDown(array, finalMessage, leftIndex, rightIndex, state);
            Thread.Sleep((int)(refreshRate * 1));
        }

        private void dispayAllArray(int[] array, string message, int leftIndex, int rightIndex, State state) {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = textColor;

            Console.WriteLine(message);
            Console.WriteLine();

            DisplayMatrix displayMatrix = generateDispalyMatrixSameLine(array, message, leftIndex, rightIndex, state);

            for (int i = 0; i < displayMatrix.getHeight(); i++) {
                for (int j = 0; j < displayMatrix.getWidth(); j++) {
                    Console.ForegroundColor = displayMatrix.getArrayTuple()[i, j].Item1;
                    Console.Write(displayMatrix.getArrayTuple()[i, j].Item2);
                }
                Console.WriteLine();
            }
        }

        private void liftUp(int[] array, string message, int leftIndex, int rightIndex, State state) {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = textColor;

            Console.WriteLine(message);
            Console.WriteLine();

            DisplayMatrix displayMatrix = generateDispalyMatrix(array, message, leftIndex, rightIndex, state);

            for (int i = 0; i < displayMatrix.getHeight(); i++) {
                for (int j = 0; j < displayMatrix.getWidth(); j++) {
                    Console.ForegroundColor = displayMatrix.getArrayTuple()[i, j].Item1;
                    Console.Write(displayMatrix.getArrayTuple()[i, j].Item2);
                }
                Console.WriteLine();
            }
        }
       
        private void switchWithplaces(int[] array, string message, int leftIndex, int rightIndex, State state) {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = textColor;

            Console.WriteLine(message);
            Console.WriteLine();

            int[] switchedArray = (int[])array.Clone();
            int tmp = switchedArray[leftIndex];
            switchedArray[leftIndex] = switchedArray[rightIndex];
            switchedArray[rightIndex] = tmp;

            DisplayMatrix displayMatrix = generateDispalyMatrix(switchedArray, message, leftIndex, rightIndex, state);

            for (int i = 0; i < displayMatrix.getHeight(); i++) {
                for (int j = 0; j < displayMatrix.getWidth(); j++) {
                    Console.ForegroundColor = displayMatrix.getArrayTuple()[i, j].Item1;
                    Console.Write(displayMatrix.getArrayTuple()[i, j].Item2);
                }
                Console.WriteLine();
            }
        }

        private void lowerDown(int[] array, string message, int leftIndex, int rightIndex, State state) {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = textColor;

            Console.WriteLine(message);
            Console.WriteLine();

            int[] switchedArray = (int[])array.Clone();
            int tmp = switchedArray[leftIndex];
            switchedArray[leftIndex] = switchedArray[rightIndex];
            switchedArray[rightIndex] = tmp;

            DisplayMatrix displayMatrix = generateDispalyMatrixSameLine(switchedArray, message, leftIndex, rightIndex, state);

            for (int i = 0; i < displayMatrix.getHeight(); i++) {
                for (int j = 0; j < displayMatrix.getWidth(); j++) {
                    Console.ForegroundColor = displayMatrix.getArrayTuple()[i, j].Item1;
                    Console.Write(displayMatrix.getArrayTuple()[i, j].Item2);
                }
                Console.WriteLine();
            }
        }

    }
}
