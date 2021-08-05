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
    public class RedBlackTreeTests
    {

        [TestMethod()]
        public void RedBlackTreeTest()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            //act
            //assert
            Assert.AreEqual(0, bst.Count);
        }
        [TestMethod()]
        public void AddTest()
        {

            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Add(15);
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 6, 15, 8, 7, 5 }));
        }
        [TestMethod()]
        public void AddItemsTestPostorder()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 6, 8, 7, 5 }));
        }
        [TestMethod()]
        public void AddItemsTestInorder()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();

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
            RedBlackTree<int> bst = new RedBlackTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void Remove_If_item_doesnt_exist_Test()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            //act
            bst.Remove(5);
            //assert
            Assert.AreEqual(bst.Count, 0);
        }
        [TestMethod()]
        public void RemoveTestPreorder()
        {

            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void RemoveTestPostorder()
        {

            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void RemoveTestInorder()
        {

            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
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
            RedBlackTree<int> bst = new RedBlackTree<int>();
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
            RedBlackTree<int> bst = new RedBlackTree<int>();
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
            RedBlackTree<int> bst = new RedBlackTree<int>();
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
        public void PostorderTest()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 6, 8, 7, 5 }));
        }
        [TestMethod()]
        public void InorderTest()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void PreorderTest()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();

            List<int> array = new List<int>();
            //act
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void CountTest_After_Add_and_Remove()
        {
            //arrange
            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            bst.Add(-5);
            List<int> array = new List<int>();
            //act
            bst.Remove(3);
            array = bst.Inorder().ToList();
            //assert
            Assert.AreEqual(bst.Count, 8);
        }
    }
}
    
