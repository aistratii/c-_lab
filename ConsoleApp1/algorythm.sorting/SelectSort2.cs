using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting {
    class SelectSort2 : SortingAlgorythm {
        private int[] originalArray;
        private int[] finalResult;
        private PrintQueue printQueue;

        public SelectSort2(int[] array) {
            originalArray = array;
            this.printQueue = new PrintQueue(0.7f);
        }


        public void sort() {
            int leftIndex = 0;
            finalResult = (int[])originalArray.Clone();

            printQueue.push(originalArray, "Original array", 0, 0, State.NONE);

            while (leftIndex < originalArray.Length) {
                int minIndex = findMinIndex(finalResult, leftIndex);

                finalResult = shiftRight(finalResult, minIndex, leftIndex);
                leftIndex++;
            }

            printQueue.push(finalResult, null, 0, 0, State.DONE);
        }


        private int[] shiftRight(int[] originalArray, int minIndex, int leftIndex) {
            int[] array = (int[])originalArray.Clone();

            if (minIndex != leftIndex) { 
                printQueue.push(array, null, leftIndex, minIndex, State.SWITCHING);

                int tmp = array[leftIndex];
                array[leftIndex] = array[minIndex];
                array[minIndex] = tmp;
            }

            return array;
        }

        public int[] getFinalArray() {
            for (int i = 0; i < finalResult.Length; i++)
                Console.Write(finalResult[i] + " ");

            return finalResult;
        }


        private int findMinIndex(int[] array, int leftIndex) {
            if (array.Length == 1)
                return 0;
            else {

                int lastMinIndex = leftIndex;
                for (int i = leftIndex +1; i < array.Length; i++) {
                    printQueue.push(array, null, lastMinIndex, i, State.COMPARING);

                    if (array[lastMinIndex] > array[i]) {
                        lastMinIndex = i;
                    } 
                }

                return lastMinIndex;
            }
        }
       

        public void animate() {
            printQueue.printAll();
        }
    }
}
