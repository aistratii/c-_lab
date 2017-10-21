using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting.animation {
    abstract class Animation {

        protected float refreshRate;
        protected ConsoleColor defaultCharColor = ConsoleColor.White;
        protected ConsoleColor textColor = ConsoleColor.DarkGray;

        public Animation(float refreshRate) {
            this.refreshRate = refreshRate;
        }

        abstract public void animate(int[] array, string message, int leftIndex, int rightIndex, State state);

        protected int checkAndAddNewLine(int newItemOnTheList, int lineCharFillMeter) {
            int width = Console.WindowWidth;
            int characterWidth = 3;

            bool isBiggerThanTheLine = (1 + newItemOnTheList.ToString().Length + lineCharFillMeter) * characterWidth > width / characterWidth;

            if (isBiggerThanTheLine) {
                lineCharFillMeter = 0;
                Console.WriteLine();
                Console.WriteLine();
            } else {
                lineCharFillMeter += (1 + newItemOnTheList.ToString().Length) * characterWidth;
            }

            return lineCharFillMeter;
        }

        protected DisplayMatrix generateDispalyMatrix(int[] array, string message, int leftIndex, int rightIndex, State state) {
            DisplayMatrix dispalyMatrix = new DisplayMatrix((array.Select(x => x.ToString().Length + 1).Sum() / Console.WindowWidth + 1) * 2, Console.WindowWidth);

            int widthIndex = 0;
            int heightIndex = 1;

            for (int arrayIdx = 0; arrayIdx < array.Length; arrayIdx++) {
                if ((widthIndex + array[arrayIdx].ToString().Length + 2) > dispalyMatrix.getWidth()) {
                    widthIndex = 0;
                    heightIndex += 2;
                }

                foreach (char character in array[arrayIdx].ToString().ToCharArray()) {
                    if (arrayIdx == leftIndex || arrayIdx == rightIndex) {
                        dispalyMatrix.getArrayTuple()[heightIndex - 1, widthIndex++] = Tuple.Create((ConsoleColor)state, character);
                    } else {
                        dispalyMatrix.getArrayTuple()[heightIndex, widthIndex++] = Tuple.Create(defaultCharColor, character);
                    }
                }
                widthIndex++;
            }

            return dispalyMatrix;
        }

        protected DisplayMatrix generateDispalyMatrixSameLine(int[] array, string message, int leftIndex, int rightIndex, State state) {
            DisplayMatrix dispalyMatrix = new DisplayMatrix((array.Select(x => x.ToString().Length +1).Sum() / Console.WindowWidth +1) * 2, Console.WindowWidth);

            int widthIndex = 0;
            int heightIndex = 1;

            for (int arrayIdx = 0; arrayIdx < array.Length; arrayIdx++) {
                if ((widthIndex + array[arrayIdx].ToString().Length + 2) > dispalyMatrix.getWidth()) {
                    widthIndex = 0;
                    heightIndex += 2;
                }

                foreach (char character in array[arrayIdx].ToString().ToCharArray()) {
                    if (arrayIdx == leftIndex || arrayIdx == rightIndex) {
                        dispalyMatrix.getArrayTuple()[heightIndex, widthIndex++] = Tuple.Create((ConsoleColor)state, character);
                    } else {
                        dispalyMatrix.getArrayTuple()[heightIndex, widthIndex++] = Tuple.Create(defaultCharColor, character);
                    }
                }
                widthIndex++;
            }

            return dispalyMatrix;
        }

        protected string convertStateToMessage(State state, int leftIndex, int rightIndex) {
            if (state == State.COMPARING)
                return "Comparing elements of index {0} with {1}".Replace("{0}", leftIndex.ToString()).Replace("{1}", rightIndex.ToString());
            else if (state == State.SWITCHING)
                return "Switching elements of index {0} with {1}".Replace("{0}", leftIndex.ToString()).Replace("{1}", rightIndex.ToString());
            else if (state == State.NOT_SWITCHING)
                return "Not switcing elements of index {0} with {1}".Replace("{0}", leftIndex.ToString()).Replace("{1}", rightIndex.ToString());
            else return "NO_MESSAGE_FOR_THIS_STATE";
        }

    }
}
