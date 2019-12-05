using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSTree;
using Prak2_Console;
using System.Collections.Generic;

namespace BSTreeLibraryTest {
    [TestClass]
    public class BSTreeTest {

        [TestMethod]
        [ExpectedException(typeof(StudentTestException))]
        public void CreateStudent_TestMarkIsHigherThan100_ShouldThrowStudentTestException() {
            //arrange
            Student st = new Student("Mike", "Chumak", "Programming", 80);
            //act
            st.TestResult = 105;
        }

        [TestMethod]
        [ExpectedException(typeof(StudentTestException))]
        public void CreateStudent_TestMarkIsLowerThan0_ShouldThrowStudentTestException() {
            //arrange
            Student st = new Student("Mike", "Chumak", "Programming", 80);
            //act
            st.TestResult = -10;
        }

        [TestMethod]
        public void CompareStudents_StudentBHasHigherMarkThanStudentA_ShouldReturnValueMinus1() {
            //arrange
            Student A = new Student("", "", "", 60);
            Student B = new Student("", "", "", 70);
            //act
            int res = A.CompareTo(B);
            //assert
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        public void CompareStudents_StudentBHasLoverMarkThanStudentA_ShouldReturnValue1() {
            //arrange
            Student A = new Student("", "", "", 60);
            Student B = new Student("", "", "", 50);
            //act
            int res = A.CompareTo(B);
            //assert
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void CompareStudents_StudentBHasTheSameParametrsAsStudentA_ShouldReturnValue0() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 50);
            //act
            int res = A.CompareTo(B);
            //assert
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Clear_ClearTreeFilledWithStudent_ShouldReturnNullRoot() {
            //arrange
            Student A = new Student("", "", "", 50);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Clear();
            var res = bSTree.Root;
            //assert
            Assert.AreEqual(null, res);
            
        }

        [TestMethod]
        [ExpectedException(typeof(NullTreeNodeException))]
        public void Insert_InsertNullStudent_ShouldReturnNullTreeNodeException() {
            //arrange
            Student A = new Student("", "", "", 50);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Insert(null);
        }

        [TestMethod]
        public void Insert_InsertStudentBAsLeftChildOfStudentA_ShouldReturnRootLeftInsertedNodeWithResult40() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 40);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Insert(B);
            BSTreeNode<Student> nodeRes = bSTree.Root.Left;
            Student inserted = nodeRes.Data;
            //assert
            Assert.AreEqual(40, inserted.TestResult);
        }

        [TestMethod]
        public void Insert_InsertStudentBAsRightChildOfStudentA_ShouldReturnRootLeftInsertedNodeWithResult60() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 60);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Insert(B);
            BSTreeNode<Student> nodeRes = bSTree.Root.Right;
            Student inserted = nodeRes.Data;
            //assert
            Assert.AreEqual(60, inserted.TestResult);
        }

        [TestMethod]
        public void Insert_InsertStudentsWithSameScoreButDiferentSurnames_BStudentShouldBeLeftChild() {
            //arrange
            Student A = new Student("", "Chumak", "", 50);
            Student B = new Student("", "Adamenko", "", 50);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Insert(B);
            BSTreeNode<Student> nodeRes = bSTree.Root.Left;
            Student inserted = nodeRes.Data;
            //assert
            Assert.AreEqual(50, inserted.TestResult);
        }
        
        [TestMethod]
        public void GetMinNode_GetMinimalNodeOfATree_ShouldReturnNodeWithTestResult20() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 30);
            Student C = new Student("", "", "", 20);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            bSTree.Insert(C);

            //act
            int res = bSTree.MinimalNode(bSTree.Root).Data.TestResult;
            int expectedRes = 20;

            //assert
            Assert.AreEqual(expectedRes, res);
        }

        [TestMethod]
        [ExpectedException(typeof(NullTreeNodeException))]
        public void Find_StudentDataIsNull_ShouldReturnNullTreeNodeException() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 30);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);

            //act
            bSTree.FindNode(null);
        }

        [TestMethod]
        public void Find_StudentDataInTheTree_ShouldReturnNodeWithStudentDataAndTestResult70() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 30);
            Student C = new Student("", "", "", 70);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            bSTree.Insert(C);
            //act
            Student res = bSTree.FindNode(C).Data;
            //assert
            Assert.AreEqual(res, C);
        }

        [TestMethod]
        public void Find_StudentIsAbsent_ShouldReturnNodeWithNullValue() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 30);
            Student C = new Student("", "", "", 70);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            //act
            var res = bSTree.FindNode(C);
            //assert
            Assert.AreEqual(res, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullTreeNodeException))]
        public void Remove_RemovingNullNode_ShouldReturnNullTreeNodeException() {
            //arrange
            Student A = new Student("", "", "", 50);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            //act
            bSTree.Remove(null);
        }

        [TestMethod]
        public void Remove_RemovingNodeHavingNoChildren_ShouldRemoveNode() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 60);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            //act
            bSTree.Remove(B);
            var res = bSTree.FindNode(B);
            //assert
            Assert.AreEqual(res, null);
        }

        [TestMethod]
        public void Remove_RemovingNodeHavingRightChild_ShouldRemoveNodeAndStayChild() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 60);
            Student C = new Student("", "", "", 70);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            bSTree.Insert(C);
            //act
            bSTree.Remove(B);
            var res = bSTree.FindNode(B);
            var stayedChild = bSTree.FindNode(C).Data;
            //asserts
            Assert.AreEqual(res, null);
            Assert.AreEqual(stayedChild, C);
        }

        [TestMethod]
        public void Remove_RemovingNodeHavingLeftChild_ShouldRemoveNodeAndStayChild() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 60);
            Student C = new Student("", "", "", 55);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            bSTree.Insert(C);
            //act
            bSTree.Remove(B);
            var res = bSTree.FindNode(B);
            var stayedChild = bSTree.FindNode(C).Data;
            //asserts
            Assert.AreEqual(res, null);
            Assert.AreEqual(stayedChild, C);
        }

        [TestMethod]
        public void Remove_RemovingNodeHavingTwoChildren_ShouldRemoveNodeAndStayChildren() {
            //arrange
            Student A = new Student("", "", "", 50);
            Student B = new Student("", "", "", 60);
            Student C = new Student("", "", "", 55);
            Student D = new Student("", "", "", 70);
            BSTree<Student> bSTree = new BSTree<Student>(A);
            bSTree.Insert(B);
            bSTree.Insert(C);
            bSTree.Insert(D);
            //act
            bSTree.Remove(B);
            var res = bSTree.FindNode(B);
            var stayedLeftChild = bSTree.FindNode(C).Data;
            var stayedRightChild = bSTree.FindNode(D).Data;
            //asserts
            Assert.AreEqual(res, null);
            Assert.AreEqual(stayedLeftChild, C);
            Assert.AreEqual(stayedRightChild, D);
        }

    }
}
