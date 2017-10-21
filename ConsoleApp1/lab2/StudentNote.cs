using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.lab2 {
    class StudentNote {
        //studenti - contine lista de studenti
        //obiecte - contine lista de obiecte
        //note - contine lista de note
        private double[,][] array;

        public void initArray() {
            Random random = new Random();

            int studLength = 6;
            int subjectsLength = 7;
            int marksLength = 6;
            int marksDela = 3;

            array = new double[studLength, subjectsLength][];
            
            for (int stud = 0; stud < studLength; stud++) 
                for (int subj = 0; subj < subjectsLength; subj++){
                    array[stud, subj] = new double[marksLength + random.Next(marksDela)];
                }



            //TODO: not finished
        }
    }
}
