using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting {
    class CombSort : SortingAlgorythm {
        private int[] originalArray;
        private int[] finalArray;
        private PrintQueue printQueue;

        public CombSort(int[] input) {
            this.originalArray = input;
            this.finalArray = input;
            this.printQueue = new PrintQueue(0.5f);
        }

        public void sort() {
            int range = (finalArray.Length * 10) / 13;

            printQueue.push(originalArray, "Original array", 0, 0, State.NONE);

            do { 
                Tuple<int, int[]> rangeAndArray = parseOnce(range, finalArray);

                range = rangeAndArray.Item1;
                finalArray = rangeAndArray.Item2;
            }
            while (range != 0);

            printQueue.push(finalArray, null, 0, 0, State.DONE);
        }

        private Tuple<int, int[]> parseOnce(int range, int[] array) {

            for (int i = 0; i < array.Length - range; i++) {
                printQueue.push(array, null, i, i + range, State.COMPARING);

                int j = i + range;
                array = compareAndSwitch(array, i, j);
            }

            return Tuple.Create((range * 10) / 13, array);
        }

        private int[] compareAndSwitch(int[] array, int i, int j) {
            int[] result = (int[])array.Clone();

            if (result[i] > result[j]) {
                printQueue.push(array, null, i, j, State.SWITCHING);

                int temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            } else {
                printQueue.push(array, null, i, j, State.NOT_SWITCHING);
            }

            return result;
        }

        public int[] getFinalArray() {
            printArrayWithMessage("Final resultarray", finalArray);

            return finalArray;
        }

        private void printArrayWithMessage(string message, int[] array) {
            Console.WriteLine(message);
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        public void animate() {
            printQueue.printAll();
        }
    }
}
