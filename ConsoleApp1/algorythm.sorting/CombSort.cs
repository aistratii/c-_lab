using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting {
    class CombSort : SortingAlgorythm {
        private int[] originalArray;
        private int[] finalArray;

        public CombSort(int[] input) {
            this.originalArray = input;
            this.finalArray = input;
        }

        public void sort() {
            int range = (finalArray.Length * 10) / 13; // "%" ?

            printArrayWithMessage("Original array", originalArray);

            do {
                Console.WriteLine("*************************");

                Tuple<int, int[]> rangeAndArray = parseOnce(range, finalArray);

                Console.WriteLine("New range: " + range);

                range = rangeAndArray.Item1;
                finalArray = rangeAndArray.Item2;
            }
            while (range != 0);
        }

        private Tuple<int, int[]> parseOnce(int range, int[] array) {
            printArrayWithMessage("Analyzing: ", array);

            for (int i = 0; i < array.Length - range; i++) {
                int j = i + range;
                array = compareAndSwitch(array, i, j);
            }

            return Tuple.Create((range * 10) / 13, array);
        }

        private int[] compareAndSwitch(int[] array, int i, int j) {
            int[] result = new int[array.Length];

            for (int x = 0; x < array.Length; x++)
                result[x] = array[x];

            Console.WriteLine("Comparing position {0}(value = {1}) with {2}(value = {3})", i, array[i], j, array[j]);

            if (result[i] > result[j]) {
                Console.WriteLine("Switching {0} with {1}", i, j);
                printArrayWithBrackets(array, i, j);

                int temp = result[i];
                result[i] = result[j];
                result[j] = temp;

                printArrayWithMessage("Resulted array: ", result);
            }

            return result;
        }

        private void printArrayWithBrackets(int[] array, params int[] indexes) {
            for (int i = 0; i < array.Length; i++)
                if (indexes.Contains(i))
                        Console.Write("[{0}] ", array[i]);
                    else
                        Console.Write(array[i] + " ");
            Console.WriteLine();
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
            throw new NotImplementedException();
        }
    }
}
