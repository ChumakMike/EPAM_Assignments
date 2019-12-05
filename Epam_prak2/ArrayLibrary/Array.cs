using System;

namespace ArrayLibrary {

    public class Array<T> {

        private T[] array;
        private int first;
        private int last;
        private int arrLen;

        public Array(int first, int last, params T[] arr) {
            if (first > last) throw new ArrayUncorrectIndexException("Uncorrect indexes of array!");
            this.first = first;
            this.last = last;
            arrLen = last - first + 1;
            if (arrLen < arr.Length) {
                this.arrLen = arr.Length;
                this.last = arrLen - 1;
                array = new T[arrLen];
                fillArr(array, arr, arrLen);
            }
            else if (arrLen >= arr.Length) {
                array = new T[arrLen];
                fillArr(array, arr, arr.Length);
            }
        }

        private static void fillArr(T[] To, T[] From, int length) {
            if (length > 0) {
                for (int i = 0; i < length; i++) {
                    To[i] = From[i];
                }
            } else throw new IndexOutOfRangeException();
        }

        public int First {
            get { return first; }
        }
        public int Last {
            get { return last; }
        }

        public int ArrLen {
            get { return arrLen; }
        }

        public T this[int index] {
            get {
                if(index >= first && index <= last) {
                    return array[index - first];
                } else {
                    throw new IndexOutOfRangeException();
                }
            }
            set {
                if(index >= first && index <= last) {
                    array[index - first] = value;
                } else {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Print() {
            Console.WriteLine();
            foreach(T el in array) {
                Console.WriteLine($" {el.ToString()} ");
            }
        }


    }
}
