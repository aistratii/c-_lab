﻿using CLab.ConsoleApp1.lab2;
using ConsoleApp1.algorythm.sorting;
using ConsoleApp1.lab2;
using ConsoleApp1.lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLab {
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

            //Lab2
            //Ecuation ec = new Ecuation(3, 3);
            //double some = 3256532.6d;
            //Console.WriteLine(some.ToString());


            //Lab3
            //StudentNote studentNote = new StudentNote(false);
            //int student = 1;
            //int subj = 1;
            //Console.WriteLine("Media pentru studentul {0} la obiectul {1} este {2}",
            //    studentNote.getStudents()[student],
            //    studentNote.getSubjects()[subj],
            //    studentNote.mediaPentruStudentLaObiect(student, subj));

            CompoundNumber[,] matrix4 = new CompoundNumber[4, 5] { 
                { new CompoundNumber(-1), new CompoundNumber(-2), new CompoundNumber(0) , new CompoundNumber(3), new CompoundNumber(-6)}, 
                { new CompoundNumber(2), new CompoundNumber(3), new CompoundNumber(4), new CompoundNumber(4), new CompoundNumber(22)},
                { new CompoundNumber(2), new CompoundNumber(2), new CompoundNumber(3), new CompoundNumber(5), new CompoundNumber(20)},
                { new CompoundNumber(3), new CompoundNumber(1), new CompoundNumber(-5), new CompoundNumber(7), new CompoundNumber(-34)} };
            CompoundNumber[,] matrix3 = new CompoundNumber[3, 4] {
                { new CompoundNumber(-1), new CompoundNumber(2), new CompoundNumber(0) , new CompoundNumber(6)},
                { new CompoundNumber(2), new CompoundNumber(3), new CompoundNumber(4), new CompoundNumber(40)},
                { new CompoundNumber(2), new CompoundNumber(2), new CompoundNumber(3), new CompoundNumber(30)}
            };

            //TODO: Investigate determinant calculation for 3+ levels

            Ecuation ecuation = new Ecuation();
            ecuation.setEcuation(matrix4);
            //ecuation.solve();
            //ecuation.prettyPrint();
            Console.WriteLine(new Determinant(
                     new int[4, 4] {
                         { 1, 2, 3, -2},
                         { -1, 0, 5, 1},
                         { 4, 1, -1, 3},
                         { 3, 2, 1, 4}
                     }
                     /*new int[4, 4] {
                        { 1, 0, 0, 0},
                        { -1, 2, 8, -1},
                        { -4, -7, -13, 11},
                        { 3, -4, -8, 10}
                    }*/

                ).getValue());//should be 264

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
