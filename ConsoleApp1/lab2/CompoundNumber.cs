using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.lab2 {
    class CompoundNumber {
        public int numerator, denominator;

        public CompoundNumber(int value) {
            this.numerator = value;
            denominator = 1;
        }

        public CompoundNumber(int numerator, int denominator) {
            this.numerator = numerator;
            this.denominator = denominator;

            if (numerator != 0)
                simplify();
        }

        private void simplify() {
            bool wasSimplified = false;

            do {
                wasSimplified = false;
                for (int i = 10; i > 1; i--)
                    if (numerator % i == 0 && denominator % i == 0) {
                        this.numerator /= i;
                        this.denominator /= i;
                        wasSimplified = true;
                    }
            }
            while (wasSimplified);
        }

        public void setNumerator(int numerator) {
            this.numerator = numerator;
        }

        public void setDenominator(int denominator) {
            this.denominator = denominator;
        }

        public int getNumerator() {
            return numerator;
        }

        public int getDenominator() {
            return denominator;
        }

        public static CompoundNumber operator*(CompoundNumber first, CompoundNumber second) {
            return new CompoundNumber(
                first.getNumerator() * second.getNumerator(),
                first.getDenominator() * second.getDenominator());
        }

        public static CompoundNumber operator-(CompoundNumber first, CompoundNumber second) {
            if (first.getDenominator() == second.getDenominator()) { 
                return new CompoundNumber(
                    first.getNumerator() - second.getNumerator(),
                    first.getDenominator());
            } else {
                return new CompoundNumber(
                    first.getNumerator() * second.getDenominator() - second.getNumerator() * first.getDenominator(),
                    first.getDenominator() * second.getDenominator());
            }
        }

        public static CompoundNumber operator +(CompoundNumber first, CompoundNumber second) {
            if (first.getDenominator() == second.getDenominator()) { 
                return new CompoundNumber(
                    first.getNumerator() + second.getNumerator(),
                    first.getDenominator());
            } else {
                return new CompoundNumber(
                    first.getNumerator() * second.getDenominator() + second.getNumerator() * first.getDenominator(),
                    first.getDenominator() * second.getDenominator());
            }
        }

        public static CompoundNumber operator /(CompoundNumber first, CompoundNumber second) {
            return new CompoundNumber(
                first.getNumerator() * second.getDenominator(),
                first.getDenominator() * second.getNumerator());
        }


        internal bool isNonNegative() {
            try {  
                return numerator / denominator >= 0;
            } catch (DivideByZeroException ex) {
                return true;
            }
        }

        internal bool isPositive() {
            return numerator > 0 && denominator > 0;
        }

        public override string ToString() {
            //else if (Math.Truncate(numerator/denominator).ToString().)
            /*if (denominator != 0 && numerator != 0) {
                if (numerator % denominator == 0)
                    return numerator / denominator + "";
                else
                    return numerator + "/" + denominator;
            } 
            else 
                return "0";*/
            return "[{0}/{1}]"
                .Replace("{0}", numerator.ToString())
                .Replace("{1}", denominator.ToString());
        }   
    }
}
