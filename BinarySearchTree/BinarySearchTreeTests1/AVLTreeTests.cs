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
    public class AVLTreeTests
    {
        [TestMethod()]
        public void AVLTreeTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();

            List<int> array = new List<int>();
            //act
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.Count == 0);
        }

        [TestMethod()]
        public void AddItemsPreorderTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void AddItemsPostorderTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 6, 8, 7, 5 }));
        }
        [TestMethod()]
        public void AddItemsInorderTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }
        [TestMethod()]
        public void AddTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            bst.Add(14);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 7, 6, 8, 14 }));
        }

        public void Remove_If_item_doesnt_exist_Test()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            //act
            bst.Remove(5);
            //assert
            Assert.AreEqual(bst.Count, 0);
        }
        [TestMethod()]
        public void RemoveTestPreoder()
        {

            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7, 14, 15 });

            List<int> array = new List<int>();
            //act
            bst.Remove(7);
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 8, 6, 14, 15 }));
        }
        [TestMethod()]
        public void RemoveTestPostorder()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7, 14, 15 });
            List<int> array = new List<int>();
            //act
            bst.Remove(7);
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0,1,4,3,6,15,14,8,5 }));
        }
        [TestMethod()]
        public void RemoveTestInorder()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7, 14, 15 });
            List<int> array = new List<int>();
            //act
            bst.Remove(7);
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 8, 14, 15 }));
        }
        [TestMethod()]
        public void ContainsTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7, 14, 15 });
            //act
            bool expectedtrue = bst.Contains(8);
            bool expectedfalse = bst.Contains(9);
            //assert
            Assert.IsTrue(expectedtrue);
            Assert.IsFalse(expectedfalse);
        }

        [TestMethod()]
        public void ClearTest()
        {

            //arrange
            AVLTree<int> bst = new AVLTree<int>();
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
            AVLTree<int> bst = new AVLTree<int>();
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
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Preorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 5, 3, 1, 0, 4, 7, 6, 8 }));
        }
        [TestMethod()]
        public void PostorderTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Postorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 4, 3, 6, 8, 7, 5 }));
        }
        [TestMethod()]
        public void InorderTest()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });

            List<int> array = new List<int>();
            //act
            array = bst.Inorder().ToList();
            //assert
            Assert.IsTrue(array.SequenceEqual(new int[] { 0, 1, 3, 4, 5, 6, 7, 8 }));
        }

        [TestMethod()]
        public void CountTest_After_Add_and_Remove()
        {
            //arrange
            AVLTree<int> bst = new AVLTree<int>();
            bst.AddItems(new int[] { 5, 3, 1, 4, 6, 8, 0, 7 });
            bst.Add(-5);
            //act
            bst.Remove(3);
            //assert
            Assert.AreEqual(bst.Count, 8);
        }
    }
}
