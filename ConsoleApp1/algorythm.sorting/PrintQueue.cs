using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.algorythm.sorting.animation;

namespace ConsoleApp1.algorythm.sorting {

    class PrintQueue {

        //array, message, index left, index right, State
        private List<Tuple<int[], string, int, int, State>> queue;

        private int refreshRate;

        public PrintQueue(float refreshRate) {
            queue = new List<Tuple<int[], string, int, int, State>>();
            this.refreshRate = (int)(refreshRate * 1000);
        }

        public void push(int[] array, string message, int leftIndex, int rightIndex, State state) {
            queue.Add(Tuple.Create((int[])array.Clone(), message, leftIndex, rightIndex, state));
        }

        public void printAll() {
            foreach (Tuple<int[], string, int, int, State> element in queue) {

                if (element.Item5 == State.COMPARING)
                    new AnimateComparing().animate(element.Item1, element.Item2, element.Item3, element.Item4, element.Item5);
                else if (element.Item5 == State.SWITCHING)
                    new AnimateSwitching(refreshRate).animate(element.Item1, element.Item2, element.Item3, element.Item4, element.Item5);
                else if (element.Item5 == State.NOT_SWITCHING)
                    new AnimateNotSwitching().animate(element.Item1, element.Item2, element.Item3, element.Item4, element.Item5);
                else if (element.Item5 == State.NONE)
                    new AnimateNone().animate(element.Item1, element.Item2, element.Item3, element.Item4, element.Item5);
                else if (element.Item5 == State.DONE)
                    new AnimateNone().animate(element.Item1, element.Item2, element.Item3, element.Item4, element.Item5);

                System.Threading.Thread.Sleep(refreshRate);
            }
        }
    }


    enum State {
        COMPARING = ConsoleColor.DarkYellow,
        SWITCHING = ConsoleColor.Red, 
        NOT_SWITCHING = ConsoleColor.Green,
        NONE = ConsoleColor.White,
        DONE = ConsoleColor.White
    }

}
