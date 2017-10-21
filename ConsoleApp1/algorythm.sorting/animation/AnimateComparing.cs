using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting.animation {
    class AnimateComparing : Animation {

        public AnimateComparing() : base(0) {}

        public override void animate(int[] array, string message, int leftIndex, int rightIndex, State state) {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = textColor;

            string finalMessage = !string.IsNullOrEmpty(message) ? message : convertStateToMessage(state, leftIndex, rightIndex);

            Console.WriteLine(finalMessage);
            Console.WriteLine();

            DisplayMatrix displayMatrix = generateDispalyMatrixSameLine(array, message, leftIndex, rightIndex, state);

            for (int i = 0; i < displayMatrix.getHeight(); i++) {
                for (int j = 0; j < displayMatrix.getWidth(); j++) {
                    Console.ForegroundColor = displayMatrix.getArrayTuple()[i, j].Item1;
                    Console.Write(displayMatrix.getArrayTuple()[i, j].Item2);
                }
                Console.WriteLine();
            }
        }
    }
}
