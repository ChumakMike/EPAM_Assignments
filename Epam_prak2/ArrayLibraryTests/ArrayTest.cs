using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayLibrary;

namespace ArrayLibraryTests {
    [TestClass]
    public class ArrayTest {

        [TestMethod]
        [ExpectedException(typeof(ArrayUncorrectIndexException))]
        public void Create_CreateWithFirstGreaterThanLast_ShouldThrowArrayUncorrectIndexException() {
            //arrange and act
            Array<int> arr = new Array<int>(5, 2, 1, 3, 4, 5);
        }

        [TestMethod]
        public void Create_CreateWithIncomingArrayGreaterThanLength_ShouldSetTheValueOfIncomingArray() {
            //arrange and act
            Array<int> arr = new Array<int>(0, 2, 1, 3, 4, 5, 6);

            int len = arr.ArrLen;

            //assert
            Assert.AreEqual(5, len);
        }

        [TestMethod]
        public void Create_CreateWithIncomingArrayLessThanLength_ShouldSetTheLengthBetweenFirstAndLast() {
            //arrange
            Array<int> arr = new Array<int>(-5, 2, 1, 3, 4, 5);

            //act
            int len = arr.ArrLen;
            int expectedLen = arr.Last - arr.First + 1; //8

            //assert
            Assert.AreEqual(expectedLen, len);
        }

        [TestMethod]
        public void Create_CreateWithIncomingArrayGraterThanLength_ShouldChangeLastValueToArrayLengthMinusOne() {
            //arrange and act
            Array<int> arr = new Array<int>(0, 2, 1, 3, 4, 5, 6);
            int expectedLast = 4;

            //assert
            Assert.AreEqual(expectedLast, arr.Last);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_GetWithIndexThatGraterThanLast_ShouldTrowIndexOutOfRangeException() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 3, 4, 5, 6);
            //act
            var res = arr[100];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_GetWithIndexThatLessThanLast_ShouldTrowIndexOutOfRangeException() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 3, 4, 5, 6);
            //act
            var res = arr[-1];
        }

        [TestMethod]
        public void Get_GetCorrectValueByIndex1_ShouldReturnValue3() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 3, 4, 5, 6);
            
            //act
            int res = arr[1];
            int expectedValue = 3;

            //assert
            Assert.AreEqual(expectedValue, res);
        }

        [TestMethod]
        public void Get_GetCorrectValueByNegativeRightIndex_ShouldReturnValue3() {
            //arrange
            Array<int> arr = new Array<int>(-2, 2, 1, 3, 4, 5, 6);

            //act
            int res = arr[-1];
            int expectedValue = 3;

            //assert
            Assert.AreEqual(expectedValue, res);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_SetWithIndexThatGraterThanLast_ShouldTrowIndexOutOfRangeException() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 3, 4, 5, 6);
            //act
            arr[100] = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_SetWithIndexThatLessThanLast_ShouldTrowIndexOutOfRangeException() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 3, 4, 5, 6);
            //act
            arr[-100] = 1;
        }

        [TestMethod]
        public void Set_SetCorrectValueByIndex1_ShouldReturnValue3() {
            //arrange
            Array<int> arr = new Array<int>(0, 4, 1, 2, 4, 5, 6);

            //act
            arr[1] = 3;
            int res = arr[1];
            int expectedVal = 3;

            //assert
            Assert.AreEqual(expectedVal, res);
        }

        [TestMethod]
        public void Set_SetCorrectValueByNegativeRightIndex_ShouldReturnValue3() {
            //arrange
            Array<int> arr = new Array<int>(-2, 2, 1, 2, 4, 5, 6);

            //act
            arr[-1] = 3;
            int res = arr[-1];
            int expectedValue = 3;

            //assert
            Assert.AreEqual(expectedValue, res);
        }

        [TestMethod]
        public void Create_CreateWithNegativeFirstIndex_ShouldReturnRightFirstNegativeIndexOfArray() {
            //arrange
            Array<int> arr = new Array<int>(-2, 2, 1, 3, 4, 5);

            //act
            int res = arr.First;
            int expectedValue = -2;

            //assert
            Assert.AreEqual(expectedValue, res);
        }
    }
}
