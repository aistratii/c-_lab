using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.lab3 {
    class StudentNote {
        //studenti - contine lista de studenti
        //obiecte - contine lista de obiecte
        //note - contine lista de note
        private double[][][] array;
        private KeyValuePair<String, String>[] studs;
        private string[] subjects;

        int subjectsLength = 7;
        int studLength = 6;
        int studDelta = 2;
        int marksLength = 6;
        int marksDela = 3;

        private Random random;

        public StudentNote(bool shouldAutoGenerate) {
            random = new Random();

            if (shouldAutoGenerate) {
                initSutdents();
                initSubjects();
                initMarks();

                populate();
            } else {
                readStudents();
                readSubjects();
                initMarks();
                populate();
            }
        }

        private void readSubjects() {
            Console.WriteLine("Subjects nr?");
            int subjLength = Convert.ToInt32(Console.ReadLine());
            subjectsLength = subjLength;

            subjects = new string[subjLength];

            for (int i = 0; i < subjLength; i++) {
                Console.Write("Please set name for subject {0}: ", i);
                
                subjects[i] = Console.ReadLine();
            }

            for (int j = 0; j < array.Length; j++) {
                array[j] = new double[subjLength][];
            }
        }

        private void readStudents() {
            Console.WriteLine("Student nr?");
            int studLength = Convert.ToInt32(Console.ReadLine());
            this.studLength = studLength;
            studDelta = 0;

            studs = new KeyValuePair<string, string>[studLength];
            array = new double[studLength][][];

            for (int i = 0; i < studLength; i++) {
                Console.Write(string.Format("Please set name for student {0} in format {{First}}<space>{{Last name}}: ", i));
                string longName = Console.ReadLine();

                studs[i] = new KeyValuePair<string, string>(longName.Split(new char[] { ' ' }, 2)[0], longName.Split(new char[] { ' ' }, 2)[1]);
            }
        }

        private void populate() {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    for (int k = 0; k < array[i][j].Length; k++)
                        array[i][j][k] = random.Next(10) + 1;
        }

        private void initMarks() {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = new double[marksLength + random.Next(marksDela)];
        }

        private void initSubjects() {
            for (int i = 0; i < array.Length; i++)
                array[i] = new double[subjectsLength][];
        }

        private void initSutdents() {
            array = new double[studLength + random.Next(studDelta)][][];
        }

        //1
        public int numarStudentiRestantieri() {
            int ctr = 0;

            for (int i = 0; i < array.Length; i++) {
                bool isLower = false;

                for (int j = 0; j < subjectsLength; j++)
                    if (mediaPentruStudentLaObiect(i, j) > 5d)
                        isLower = true;

                if (isLower) ctr++;
            }

            return ctr;
        }

        //2
        public double mediaPentruStudentLaObiect(int studentIndex, int subjectsIndex) {
            return array[studentIndex][subjectsIndex].Average();
        }

        //3
        public double mediaPentruTotiStudentii() {
            double avg = 0d;

            for (int i = 0; i < array.Length; i++)
                avg += mediaPentruStudent(i);

            avg /= array.Length;

            return avg;
        }

        //4
        public double mediaPentruStudent(int studentIndex) {
            //return array.Average(stud => stud.Average(subj => subj.Average()));

            double avg = 0d;

            for (int i = 0; i < subjectsLength; i++)
                avg += mediaPentruStudentLaObiect(studentIndex, i);

            avg /= subjectsLength;

            return avg;
        }

        //5
        public double mediaLaObiect(int subjectIdx) {
            double avg = 0d;

            for (int i = 0; i < array.Length; i++)
                avg += mediaPentruStudentLaObiect(i, subjectIdx);

            avg /= array.Length;

            return avg;
        }

        public string[] getSubjects() {
            return (string[])subjects.Clone();
        }

        public KeyValuePair<string, string>[] getStudents() {
            return (KeyValuePair < string, string >[] )studs.Clone();
        }

    }
}
