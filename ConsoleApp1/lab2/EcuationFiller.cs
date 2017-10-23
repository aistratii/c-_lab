using ConsoleApp1.lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLab.ConsoleApp1.lab2 {
    class EcuationFiller {

        private static int limit = 6;
        private static int commaLimit = 3;
        private static Random random;

        static EcuationFiller() {
            random = new Random();
        }

        public static void fill(Ecuation ecObj) {
            Console.WriteLine("Introduceti numarul de necunoscute.");

            int size = Int32.Parse(Console.ReadLine());

            //Read constants
            CompoundNumber[,] ecuation = new CompoundNumber[size, size+1];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size +1; j++) {

                    if (j != size )
                        Console.Write("Numarator pentru [{0}, {1}] = ", i, j);
                    else
                        Console.Write("Numaratorul rezultatului pentru linia {0} = ", i);
                    int numerator = Int32.Parse(Console.ReadLine());

                    if (j != size)
                        Console.Write("Numitorul pentru [{0}, {1}] = ", i, j);
                    else
                        Console.Write("Numitorul rezultatului pentru linia {0} = ", i);
                    int denominator = Int32.Parse(Console.ReadLine());

                    ecuation[i, j] = new CompoundNumber(numerator, denominator);
                    Console.WriteLine();
                }
            ecObj.setEcuation(ecuation);
        }

        public static void fillHardcoded(Ecuation ecObj) {
            hardcoded(ecObj);
        }


        //TODO: Doesn't work, idk why
        /*public static void fill(Ecuation ecObj, int size) {
            CompoundNumber[,] ecuation = new CompoundNumber[size, size + 1];
            CompoundNumber[] unkowns = new CompoundNumber[size];

            //populate unknowns
            for (int i = 0; i < unkowns.Length; i++)
                unkowns[i] = generateRandomCompound();

            //populate with constants
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    ecuation[i, j] = generateRandomCompound();

            //find the results
            for (int i = 0; i < size; i++) {

                CompoundNumber tmp = ecuation[i, 0] * unkowns[0];
                for (int j = 1; j < size; j++)
                    tmp = tmp + (ecuation[i, j] * unkowns[j]);

                ecuation[i, size] = tmp;
            }

            ecObj.setEcuation(ecuation);
        }*/

        private static void hardcoded(Ecuation ecObj) {
           CompoundNumber[,] matrix = new CompoundNumber[3, 4] {
                { new CompoundNumber(-1), new CompoundNumber(2), new CompoundNumber(0), new CompoundNumber(1)},
                { new CompoundNumber(1), new CompoundNumber(1), new CompoundNumber(1), new CompoundNumber(2)},
                { new CompoundNumber(1), new CompoundNumber(-1), new CompoundNumber(-1), new CompoundNumber(0)}};

            ecObj.setEcuation(matrix);
        }

        private static void addResultsInArrat(Tuple<CompoundNumber, CompoundNumber>[,] ecuationArray) {
            throw new NotImplementedException();
        }

        private static int generateNumber() {
            int sign = random.Next(limit) > limit / 2 ? 1 : -1;
            int some = sign * random.Next(limit);

            return some;
        }

        private static CompoundNumber generateRandomCompound() {
            int sign = random.Next(limit) > (limit / 2) ? 1 : -1;

            return new CompoundNumber(sign* generateNumber(), generateNumber());
        }
    }
}
