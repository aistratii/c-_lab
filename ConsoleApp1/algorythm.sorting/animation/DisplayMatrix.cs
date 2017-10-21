using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.algorythm.sorting.animation {

    class DisplayMatrix {
        private Tuple<ConsoleColor, char>[,] array;
        private int width, height;

        public DisplayMatrix(int height, int width) {
            this.width = width;
            this.height = height;

            array = new Tuple<ConsoleColor, char>[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    array[i, j] = Tuple.Create(ConsoleColor.White, ' ');
        }

        public int getWidth() {
            return width;
        }

        public int getHeight() {
            return height;
        }

        public Tuple<ConsoleColor, char>[,] getArrayTuple() {
            return array;
        }

    }
}
