using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting {
    class BubbleSort : SortingAlgorythm{
        private int[] originalArray;
        private int[] finalArray;
        private PrintQueue printQueue;

        public BubbleSort(int[] input) {
            this.originalArray = input;
            this.finalArray = input;
            this.printQueue = new PrintQueue(0.5f);
        }

        public void sort() {
            //printArrayWithMessage("Original array", originalArray);
            printQueue.push(originalArray, "Original array", 0, 0, State.NONE);

            Boolean hasChanged = false;
            do {
                //Console.WriteLine("---------------------");
                //printArrayWithMessage("Parsing the aray...", finalArray

                Tuple<int[], bool> arrayAndFlag = parseOnce(finalArray);
                finalArray = arrayAndFlag.Item1;
                hasChanged = arrayAndFlag.Item2;
            } while (hasChanged);

            //Console.WriteLine("---------------------");
            //Console.WriteLine("Done");
            printQueue.push(finalArray, "Done", 0, 0, State.DONE);
        }


        private Tuple<int[], bool> parseOnce(int[] finalArray) {
            Boolean hasChanged = false;
            for (int i = 0; i < finalArray.Length -1; i++) {
                Tuple<int[], bool> arrayAndFlag = compareAndSwitch(i, i + 1, finalArray);
                finalArray = arrayAndFlag.Item1;
                if (!hasChanged)
                    hasChanged = arrayAndFlag.Item2;

            }
            return Tuple.Create(finalArray, hasChanged);
        }

        private Tuple<int[], bool> compareAndSwitch(int i, int j, int[] array) {
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            bool hasChanged = false;

            printQueue.push(tempArray, null, i, j, State.COMPARING);

            if (tempArray[i] > tempArray[j]) {
                //printSwitching(array, i, j);
                printQueue.push(tempArray, null, i, j, State.SWITCHING);

                int temp = tempArray[i];
                tempArray[i] = tempArray[j];
                tempArray[j] = temp;
                hasChanged = true;
            } else {
                printQueue.push(tempArray, null, i, j, State.NOT_SWITCHING);
            }
            return Tuple.Create(tempArray, hasChanged);
        }

        public int[] getFinalArray() {
            for (int i = 0; i < finalArray.Length; i++)
                Console.Write(finalArray[i]);
            Console.WriteLine();

            return finalArray;
        }

        private void printSwitching(int[] array, int i, int j) {
            Console.WriteLine("Switching " + i +"[" + array[i] +"] with " + j + "[" + array[j] + "]");

            for (int k = 0; k < array.Length; k++)
                if (k == i || k == j)
                    Console.Write("[" + array[k] + "] ");
                else Console.Write(array[k] + " ");

            Console.WriteLine();
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
