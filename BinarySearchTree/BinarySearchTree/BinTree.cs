using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BinarySearchTree
{
    /// <summary>
    /// Представляет структуру данных бинарного дерева
    /// </summary>
    public class BinTree<T> : ITree<T>
        where T : IComparable
    {
        /// <summary>
        /// Корень дерева <see cref="BinTree{T}"/>.
        /// </summary>
        internal BinTreeNode<T> Root { get; set; }

        /// <summary>
        /// Количество элементов в <see cref="BinTree{T}"/>.
        /// </summary>
        public virtual int Count { get; internal set; }

        /// <summary>
        /// Создает новый экземпляр <see cref="BinTree{T}"/>.
        /// </summary>
        public BinTree()
        {
            Root = null;
            Count = 0;
        }
        /// <summary>
        /// Добавляет элементы, представленные в виде перечесляемой коллекции <see cref="BinTree{T}"/>.
        /// </summary>
        /// <param name="array">Значение которое нужно добавить.</param>
        public virtual void AddItems(IEnumerable<T> array)
        {
            foreach (var item in array)
                Add(item);
        }
        /// <summary>
        /// Добавляет элемент в <see cref="BinTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно добавить.</param>
        public virtual void Add(T value)
        {
            if (Root == null)
            {
                Root = new BinTreeNode<T>(value);
                Count++;
                return;
            }

            var curNode = Root;
            var lastNode = Root;
            bool addedToLeftSide = true;

            while (curNode != null)
            {


                if (value.CompareTo(curNode.Value) < 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Left;
                    addedToLeftSide = true;
                }
                else if (value.CompareTo(curNode.Value) > 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Right;
                    addedToLeftSide = false;
                }
                else return;

            }
            if (addedToLeftSide)
            {
                lastNode.Left = new BinTreeNode<T>(value);
                Count++;
            }
            else
            {
                lastNode.Right = new BinTreeNode<T>(value);
                Count++;
            }
        }

        /// <summary>
        /// Удаляет элемент из <see cref="BinTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно удалить.</param>
        /// 

        public virtual void Remove(T value)
        {
            Remove(Root, value);
            Count--;
        }
        private BinTreeNode<T> Remove(BinTreeNode<T> node, T value)
        {
            if (node == null)
                return node;
            if (value.CompareTo(node.Value) < 0)
                node.Left = Remove(node.Left, value);
            else if (value.CompareTo(node.Value) > 0)
                node.Right = Remove(node.Right, value);
            else if (node.Left != null && node.Right != null)
            {
                node.Value = FindMin(node.Right).Value;
                node.Right = Remove(node.Right, node.Value);
            }
            else if (node.Left != null)
                node = node.Left;
            else if (node.Right != null)
                node = node.Right;
            else
                node = null;
            return node;
        }

        /// <summary>
        /// Находит минимальную вершину в поддереве 
        /// </summary>
        /// <returns>Корень поддерева</returns>
        private BinTreeNode<T> FindMin(BinTreeNode<T> node)
        {
            if (node.Left == null)
                return node;
            return FindMin(node.Left);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <summary>
        /// Определяет наличие значения в дереве <see cref="BinTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно проверить.</param>
        /// <returns>true если дерево содержит данное значение, иначе false.</returns>
        public virtual bool Contains(T value)
        {
            if (Root == null) return false;
            var curNode = Root;
            while (curNode != null)
            {
                if (value.CompareTo(curNode.Value) == 0) return true;
                if (value.CompareTo(curNode.Value) < 0) curNode = curNode.Left;
                if (value.CompareTo(curNode.Value) > 0) curNode = curNode.Right;
            }
            return false;
        }

        /// <summary>
        /// Удаляет все элементы в <see cref="BinTree{T}"/>.
        /// </summary>
        public virtual void Clear()
        {
            if (Root != null)
            {
                HashSet<BinTreeNode<T>> cleared = new HashSet<BinTreeNode<T>>();
                Stack<BinTreeNode<T>> stack = new Stack<BinTreeNode<T>>();
                stack.Push(Root);
                while (stack.Count > 0)
                {
                    BinTreeNode<T> curNode = stack.Peek();

                    if (curNode.Left == null || cleared.Contains(curNode.Left))
                    {
                        cleared.Add(curNode);
                        stack.Pop();

                        if (curNode.Right != null) stack.Push(curNode.Right);

                        curNode.Invalidate();
                    }
                    else stack.Push(curNode.Left);
                }
            }

            Root = null;
            Count = 0;
        }
        /// <summary>
        /// Итератор дерева
        /// </summary>
        /// <returns>Возвращает элементы все элементы дерева согласно методу обхода в ширину</returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            if (Root == null)
                yield break;

            var queue = new Queue<BinTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BinTreeNode<T> node = queue.Dequeue();
                yield return node.Value;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }
        /// <summary>
        /// Обратный обход дерева
        /// </summary>
        /// <returns>Список вершин, пройденные согласно обратному обходу</returns>
        public IList<T> Postorder()
        {
            IList<T> items = new List<T>();
            Postorder(ref items, Root);
            return items;
        }

        private void Postorder(ref IList<T> items, BinTreeNode<T> node)
        {
            if (node != null)
            {
                Postorder(ref items, node.Left);
                Postorder(ref items, node.Right);
                items.Add(node.Value);
            }
        }
        /// <summary>
        /// Прямой обход дерева
        /// </summary>
        /// <returns>Список вершин, пройденные согласно прямому обходу</returns>
        public IList<T> Preorder()
        {
            IList<T> items = new List<T>();
            Preorder(ref items, Root);
            return items;
        }
        private void Preorder(ref IList<T> items, BinTreeNode<T> node)
        {
            if (node != null)
            {
                items.Add(node.Value);
                Preorder(ref items, node.Left);
                Preorder(ref items, node.Right);

            }
        }
        /// <summary>
        /// Обратный обход дерева
        /// </summary>
        /// <returns>Список вершин, пройденные согласно симметричному обходу</returns>
        public IList<T> Inorder()
        {
            IList<T> items = new List<T>();
            Inorder(ref items, Root);
            return items;
        }
        private void Inorder(ref IList<T> items, BinTreeNode<T> node)
        {
            if (node != null)
            {
                Inorder(ref items, node.Left);
                items.Add(node.Value);
                Inorder(ref items, node.Right);
            }
        }
        #region Print Tree(deletable)
        public virtual Image Print(PictureBox image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Paint(graphics, Root, image.Width / 2, 50, 1);
            return bmp;
        }
        private void Paint(Graphics graphics, BinTreeNode<T> node, int x, int y, int level)
        {
            if (node == null)
                return;
            int z = Convert.ToInt32(500 / Math.Pow(2, level));

            if (node.Left != null)
                graphics.DrawLine(Pens.Black, x + 25, y + 25, x - z + 25, y + 100);
            if (node.Right != null)
                graphics.DrawLine(Pens.Black, x + 25, y + 25, x + z + 25, y + 100);
            DrawRect(node, x, y, graphics);
            Paint(graphics, node.Left, x - z, y + 100, level + 1);
            Paint(graphics, node.Right, x + z, y + 100, level + 1);
        }

        private void DrawRect(BinTreeNode<T> node, int x, int y, Graphics graphics)
        {
            if (node != null)
            {
                Rectangle rect;
                rect = new Rectangle(x, y, 50, 50);
                graphics.FillEllipse(Brushes.White, rect);
                graphics.DrawEllipse(Pens.Black, rect);
                TextRenderer.DrawText(graphics, node.Value.ToString(), new Font("Times New Roman", 12.0f), rect, Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
        #endregion
    }
}

