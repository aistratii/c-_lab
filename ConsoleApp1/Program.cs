using ConsoleApp1.algorythm.sorting;
using ConsoleApp1.lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            //Lab1
            //int[] input = readInput(true);

            //SortingAlgorythm bubbleSort = new BubbleSort(input);
            //bubbleSort.sort();
            //bubbleSort.animate();

            //SortingAlgorythm selectSort = new SelectSort2(input);
            //selectSort.sort();
            //selectSort.animate();

            //SortingAlgorythm combSort = new CombSort(input);
            //combSort.sort();
            //combSort.animate();

            //Lab3
            StudentNote studentNote = new StudentNote(false);
            int student = 1;
            int subj = 1;
            Console.WriteLine("Media pentru studentul {0} la obiectul {1} este {2}",
                studentNote.getStudents()[student],
                studentNote.getSubjects()[subj],
                studentNote.mediaPentruStudentLaObiect(student, subj));

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
