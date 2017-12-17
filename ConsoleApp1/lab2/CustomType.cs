using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLab.ConsoleApp1.lab2 {
    class CustomType<T> {
        private T val;

        public T getValue() {
            return val;
        }

        public CustomType(T val) {
            this.val = val;
        }

        public static CustomType<T> operator + (CustomType<T> first, CustomType<T> second) {
            //return new CustomType<int>(first.getValue() + second.getValue());
            throw new NotImplementedException();
        }

        public static CustomType<T> operator * (CustomType<T> first, CustomType<T> second) {
            //return new CustomType<T>(first.getValue() * second.getValue());
            throw new NotImplementedException();
        }
    }
}
