using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting {
    class SelectSort2 : SortingAlgorythm {
        private int[] originalArray;
        private int[] finalResult;


        public SelectSort2(int[] array) {
            originalArray = array;
        }


        public void sort() {
            int resultIndex = 0;
            int []resultArray = new int[this.originalArray.Length];
            int []remainingArray = this.originalArray;

            printOriginal();
            while (resultIndex < originalArray.Length) {
                var minAndIndex = findMin(remainingArray);

                resultIndex = addToResult(minAndIndex.Item1, resultArray, resultIndex);
                int []newRemainingArray = excludeIndex(minAndIndex.Item2, remainingArray);

                printIntermediaryResult(resultIndex, resultArray, remainingArray, newRemainingArray, minAndIndex);

                remainingArray = newRemainingArray;
            }

            this.finalResult = resultArray;
        }


        public int[] getFinalArray() {
            for (int i = 0; i < finalResult.Length; i++)
                Console.Write(finalResult[i] + " ");

            return finalResult;
        }


        private int[] excludeIndex(int indexToExclude, int []array) {
            int []result = new int[array.Length - 1];

            int resultCounter = 0;
            for(int i = 0; i < array.Length; i++) {
                if (i != indexToExclude) {
                    result[resultCounter++] = array[i];
                }
            }

            return result;
        }


        private int addToResult(int minValue, int[] resultArray, int resultIndex) {
            resultArray[resultIndex] = minValue;
            return resultIndex + 1;
        }


        //first = value, second = index
        private Tuple<int, int> findMin(int[] remainingArray) {
            if (remainingArray.Length == 1)
                return Tuple.Create(remainingArray[0], 0);
            else { 
                int tmp = remainingArray[0];

                int lastMinIndex = 0;
                for (int i = 1; i < remainingArray.Length; i++) {
                    if (tmp > remainingArray[i]) {
                        tmp = remainingArray[i];
                        lastMinIndex = i;
                    }
                }

                return Tuple.Create(tmp, lastMinIndex);
            }
        }


        private void printOriginal() {
            Console.WriteLine("original array");
            for (int i = 0; i < originalArray.Length; i++) {
                    Console.Write(originalArray[i] + " ");
            }
            Console.WriteLine();
        }

        private void printIntermediaryResult(int resultIndex, int[] resultArray, int[] oldRemainingArray, int[] newRemainingArray, Tuple<int, int> minAndIndex) {
            Console.WriteLine("----------------------------------");

            //Console.WriteLine("resultIndex = " + resultIndex);
            Console.WriteLine("Old remaining array");
            for (int i = 0; i < oldRemainingArray.Length; i++)
                if (i == minAndIndex.Item2)
                    Console.Write("[" + oldRemainingArray[i] + "] ");
                else
                    Console.Write(oldRemainingArray[i] + " ");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Selected value");
            Console.Write(resultArray[resultIndex-1]);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result array");
            for (int i = 0; i < resultArray.Length; i++) {
                if (i == resultIndex-1)
                    Console.Write("[" + resultArray[i] + "] ");
                else
                    Console.Write(resultArray[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("New remaining array");
            for (int i = 0; i < newRemainingArray.Length; i++)
                Console.Write(newRemainingArray[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void animate() {
            throw new NotImplementedException();
        }
    }
}
