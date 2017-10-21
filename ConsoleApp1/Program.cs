using ConsoleApp1.algorythm.sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            int[] input = readInput(true);

            SortingAlgorythm selectSort2 = new BubbleSort(input);
            selectSort2.sort();
            selectSort2.animate();

            //BubbleSort bubbleSort = new BubbleSort(input);
            //bubbleSort.sort();
            //bubbleSort.getFinalArray();

            //CombSort combSort = new CombSort(input);
            //combSort.sort();
            //combSort.getFinalArray();

            Console.Read();
        }

        private static int[] readInput(bool shouldReadFromKeyboard) {
            if (!shouldReadFromKeyboard)
                return new int[]{ 3, 2, 1, 2 };
            else {
                Console.WriteLine("Array length? ");

                int length = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[length];

                for (int i = 0; i < length; i++) {
                    Console.WriteLine("Elem {0} : ", i);
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                return array;
            }
        }
    }

}
