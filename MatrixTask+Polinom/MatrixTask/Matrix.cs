using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatrixTask {

    [DataContract]
    class Matrix {
        private int rows;
        private int columns;

        [DataMember]
        private int[,] matrixArr; 

        public int Rows {
            get { return this.rows; }
        }

        public int Columns {
            get { return this.columns; }
        }

        public int[,] MatrixArr {
            get { return this.matrixArr; }
            set { this.matrixArr = value; }
        }

        public Matrix(int rows, int columns) {
            if(rows < 1 || columns < 1) {
                throw new NotRightSizeOfMatrixException();
            }
            this.rows = rows;
            this.columns = columns;
            this.matrixArr = new int[rows, columns];
        }

        public int this[int i, int j] {
            get {
                if (i < 0 || j < 0) {
                    throw new IndexOutOfRangeException();
                }
                return matrixArr[i, j];
            }
            set {
                if(i < 0 || j < 0) {
                    throw new IndexOutOfRangeException();
                }
                matrixArr[i, j] = value;
            }
        }

        public bool isEquals(Matrix matrix) {
            if (matrix is null) {
                throw new NullReferenceException();
            }
            if(this.rows != matrix.Rows || this.columns != matrix.Columns) {
                throw new NotEqualSizeException();
            } else {
                bool isEq = true;
                for (int i = 0; i < this.Rows; i++) {
                    for (int j = 0; j < this.Columns; j++) {
                        if(this.MatrixArr[i, j] != matrix.MatrixArr[i, j]) {
                            isEq = false;
                            return isEq;
                        }
                    }
                }
                return isEq;
            }
        }

        public Matrix getClone() {
            Matrix clone = new Matrix(this.rows, this.columns);
            for (int i = 0; i < this.rows; i++) {
                for (int j = 0; j < this.columns; j++) {
                    clone.MatrixArr[i, j] = this.MatrixArr[i, j];
                }
            }
            return clone;
        }

        public static Matrix operator+(Matrix first, Matrix second) {
            if(first is null || second is null) {
                throw new NullReferenceException();
            }
            if(first.Rows == second.Rows && first.Columns == second.Columns) {
                Matrix resMatrix = new Matrix(first.Rows, second.Columns);
                for (int i = 0; i < first.Rows; i++) {
                    for (int j = 0; j < first.Columns; j++) {
                        resMatrix.MatrixArr[i, j] = first.MatrixArr[i, j] + second.MatrixArr[i, j];
                    }
                }
                return resMatrix;
            } else {
                throw new NotEqualSizeException();
            }   
        }

        public static Matrix operator -(Matrix first, Matrix second) {
            if (first is null || second is null) {
                throw new NullReferenceException();
            }
            if (first.Rows == second.Rows && first.Columns == second.Columns) {
                Matrix resMatrix = new Matrix(first.Rows, second.Columns);
                for (int i = 0; i < first.Rows; i++) {
                    for (int j = 0; j < first.Columns; j++) {
                        resMatrix.MatrixArr[i, j] = first.MatrixArr[i, j] - second.MatrixArr[i, j];
                    }
                }
                return resMatrix;
            } else {
                throw new NotEqualSizeException();
            }
        }


        public static Matrix operator*(Matrix matrix, int num) {
            if(matrix is null) {
                throw new NullReferenceException();
            }

            Matrix resMatrix = new Matrix(matrix.Rows, matrix.Columns);
            for(int i = 0; i < matrix.Rows; i++) {
                for(int j = 0; j < matrix.Columns; j++) {
                    resMatrix.MatrixArr[i, j] = matrix.MatrixArr[i, j] * num;
                }
            }

            return resMatrix;
        }

        public static Matrix operator*(Matrix first, Matrix second) {
            if(first is null || second is null) {
                throw new NullReferenceException();
            }
            if(first.Columns == second.Rows) {
                Matrix resMatrix = new Matrix(second.Rows, second.Columns);
                for (int i = 0; i < first.Columns; i++) {
                    for (int j = 0; j < second.Rows; j++) {
                        for(int k = 0; k < first.Rows; k++) {
                            resMatrix.MatrixArr[i, j] = resMatrix.MatrixArr[i, j] + first.MatrixArr[i, k] * second.MatrixArr[k, j];
                        }
                    }
                }
                return resMatrix;
            } else {
                throw new NotEqualSizeException();
            }
        }

        
        public void fillRandom() {
            Random randNum = new Random();
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    matrixArr[i, j] = randNum.Next(1, 10);
                }
            }
        }

        public void printMatrix() {
            Console.WriteLine();
            for (int i = 0; i < rows; i++) {
                for(int j = 0; j < columns; j++) {
                    Console.Write( matrixArr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public string getStr() {
            string resStr = "";
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    resStr += $" {matrixArr[i,j]} ";
                }
            }
            return resStr;
        }

        public void serialize() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Matrix));

            using (FileStream fs = new FileStream("matrix.json", FileMode.OpenOrCreate)) {
                jsonFormatter.WriteObject(fs, this.getStr());
            }
            
        }

    }
}
