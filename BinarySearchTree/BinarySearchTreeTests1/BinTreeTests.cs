using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    [TestClass()]
    public class BinTreeTests
    {
        [TestMethod()]
        public void BinarySearchTreeTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            //act
            //assert
            Assert.AreEqual(0, bst.Count);
        }
        [TestMethod()]
        public void AddTest()
        {

            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Add(15);
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 7,15, 8, 6, 5 }));
        }
        [TestMethod()]
        public void AddItemsTestPostorder()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 7, 8, 6, 5 }));
        }
        [TestMethod()]
        public void AddItemsTestInorder()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void AddItemsTestPreorder()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 6, 8, 7 }));
        }

        public void Remove_If_item_doesnt_exist_Test()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            //act
            bst.Remove(5);
            //assert
            Assert.AreEqual(bst.Count,0);
        }
        [TestMethod()]
        public void RemoveTestPreorder()
        {

            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 4, 1, 0, 6, 8, 7 }));
        }
        [TestMethod()]
        public void RemoveTestPostorder()
        {

            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 4, 1, 0, 6, 8, 7 }));
        }
        [TestMethod()]
        public void RemoveTestInorder()
        {

            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void ContainsTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            //act
            bool expectedtrue = bst.Contains(5);
            bool expectedfalse = bst.Contains(9);
            //assert
            Assert.IsTrue(expectedtrue);
            Assert.IsFalse(expectedfalse);
        }

        [TestMethod()]
        public void ClearTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Clear();
            foreach (var item in bst)
            {
                array.Add(item);
            }
            //assert
            Assert.AreEqual(0, array.Count);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            foreach (var item in bst)
            {
                array.Add(item);
            }
            //assert
            Assert.AreEqual(8, array.Count);
        }
        [TestMethod()]
        public void PreorderTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 6, 8, 7 }));
        }

        [TestMethod()]
        public void InorderTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void PostorderTest()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void CountTest_After_Add_and_Remove()
        {
            //arrange
            BinTree<int> bst = new BinTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            bst.Add(-5);
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Inorder().ToList();
            //assert
            Assert.AreEqual(bst.Count,8);
        }
    }
}