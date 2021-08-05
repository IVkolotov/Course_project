using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BinarySearchTree
{
    /// <summary>
    /// Представляет структуру данных красно-чёрного дерева.
    /// </summary>
    public class RedBlackTree<T> : BinTree<T>
        where T : IComparable<T>, IComparable
    {
        /// <summary>
        /// Корень дерева <see cref="RedBlackTree{T}"/>.
        /// </summary>
        internal new RedBlackTreeNode<T> Root
        {
            get { return (RedBlackTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        /// <summary>
        /// Количество элементов в <see cref="RedBlackTree{T}"/>.
        /// </summary>
        public override int Count { get; internal set; }

        /// <summary>
        /// Создает новый экземпляр<see cref="RedBlackTree{T}"/>.
        /// </summary>
        public RedBlackTree() : base() { }


        /// <summary>
        /// Левый поворот.
        /// </summary>
        private RedBlackTreeNode<T> RotateLeft(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> m = node.Right;
            node.Right = m.Left;
            if (m.Left != null)
            {
                m.Left.Parent = node;
            }

            if (node.Parent != null)
            {
                if (node == node.Parent.Left) node.Parent.Left = m;
                else if (node == node.Parent.Right) node.Parent.Right = m;
            }
            else
            {
                Root = m;
            }

            m.Parent = node.Parent;

            m.Left = node;

            node.Parent = m;

            return m;
        }
        /// <summary>
        /// Правый поворот.
        /// </summary>
        private RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> m = node.Left;
            node.Left = m.Right;
            if (m.Right != null)
            {
                m.Right.Parent = node;
            }

            if (node.Parent != null)
            {
                if (node == node.Parent.Left) node.Parent.Left = m;
                else if (node == node.Parent.Right) node.Parent.Right = m;
            }
            else
            {
                Root = m;
            }

            m.Parent = node.Parent;

            m.Right = node;

            node.Parent = m;

            return m;
        }

        /// <summary>
        ///Добавляет элемент в <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение, которое нужно добавить.</param>
        public override void Add(T value)
        {
            if (Root == null)
            {
                Root = new RedBlackTreeNode<T>(value) { IsRed = false };
                Count = 1;
                return;
            }

            RedBlackTreeNode<T> parent = null;
            RedBlackTreeNode<T> current = Root;

            int cmp = 0;
            while (current != null)
            {
                cmp = value.CompareTo(current.Value);

                parent = current;

                if (cmp < 0) current = current.Left;
                else if (cmp > 0) current = current.Right;
                else return;
            }

            
            RedBlackTreeNode<T> newNode = new RedBlackTreeNode<T>(value);
            newNode.Parent = parent;
            Count++;

            if (cmp < 0) parent.Left = newNode;
            else parent.Right = newNode;

            BalanceAfterAdd(newNode);
        }

        private void BalanceAfterAdd(RedBlackTreeNode<T> current)
        {
            while (current != Root && current.Parent.IsRed)
            {
                var parent = current.Parent;
                var grandParent = current.Parent.Parent;
                RedBlackTreeNode<T> uncle;
                if (grandParent.Left == null || grandParent.Right == null)
                    uncle = new RedBlackTreeNode<T>(default(T)) { IsRed = false };
                else
                    uncle = grandParent.Left == parent ? grandParent.Right : grandParent.Left;


                if (uncle.IsRed) 
                {
                    parent.IsRed = false;
                    uncle.IsRed = false;
                    grandParent.IsRed = true;

                    current = grandParent;
                }
                else 
                {
                    if (parent == grandParent.Left) 
                    {
                        if (current == parent.Right) 
                        {
                            RotateLeft(parent);
                            parent = current;
                        }

                        RotateRight(grandParent);
                        
                        grandParent.IsRed = true;
                        parent.IsRed = false;
                    }
                    else if (parent == grandParent.Right) 
                    {
                        if (current == parent.Left) 
                        {
                            RotateRight(parent);
                            parent = current;
                        }

                        RotateLeft(grandParent);
                        
                        grandParent.IsRed = true;
                        parent.IsRed = false;
                    }
                }
                Root.IsRed = false;
            }
        }

        #region Удаление
        /// <summary>
        /// Удаляет элемент из <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно удалить.</param>
        public override void Remove(T value)
        {

            var curNode = Root;

            while (curNode != null)
            {


                if (value.CompareTo(curNode.Value) < 0)
                {
                    curNode = curNode.Left;
                }
                else if (value.CompareTo(curNode.Value) > 0)
                {
                    curNode = curNode.Right;
                }
                else
                {
                    if (curNode.Left != null)
                    {
                        // Находим самый большой элемент в левом поддереве
                        var subtreeNode = curNode.Left;
                        while (subtreeNode.Right != null) subtreeNode = subtreeNode.Right;
                        // Смена значений
                        T x = curNode.Value;
                        curNode.Value = subtreeNode.Value;
                        subtreeNode.Value = x;
                        // Теперь нужно удалить subtreeNode
                        RemoveNodeAndBalanceTree(nodeForRemoval: subtreeNode, isNodeForRemovalNull: false);

                        subtreeNode.Invalidate();


                        var copyNode = new RedBlackTreeNode<T>(curNode.Value)
                        {
                            Parent = curNode.Parent,
                            Left = curNode.Left,
                            Right = curNode.Right,
                            IsRed = curNode.IsRed
                        };
                        if (copyNode.Left != null) copyNode.Left.Parent = copyNode;
                        if (copyNode.Right != null) copyNode.Right.Parent = copyNode;
                        if (curNode.Parent != null)
                        {
                            if (copyNode.Parent.Left == curNode)
                                copyNode.Parent.Left = copyNode;
                            else
                                copyNode.Parent.Right = copyNode;
                        }
                        else Root = copyNode;

                        curNode.Invalidate();
                    }
                    else if (curNode.Right != null)
                    {

                        var subtreeNode = curNode.Right;
                        while (subtreeNode.Left != null) subtreeNode = subtreeNode.Left;

                        T x = curNode.Value;
                        curNode.Value = subtreeNode.Value;
                        subtreeNode.Value = x;

                        RemoveNodeAndBalanceTree(nodeForRemoval: subtreeNode, isNodeForRemovalNull: false);

                        subtreeNode.Invalidate();


                        var copyNode = new RedBlackTreeNode<T>(curNode.Value)
                        {
                            Parent = curNode.Parent,
                            Left = curNode.Left,
                            Right = curNode.Right,
                            IsRed = curNode.IsRed
                        };
                        if (copyNode.Left != null) copyNode.Left.Parent = copyNode;
                        if (copyNode.Right != null) copyNode.Right.Parent = copyNode;
                        if (curNode.Parent != null)
                        {
                            if (copyNode.Parent.Left == curNode)
                                copyNode.Parent.Left = copyNode;
                            else
                                copyNode.Parent.Right = copyNode;
                        }
                        else Root = copyNode;

                        curNode.Invalidate();
                    }
                    else
                    {

                        curNode.IsRed = false;
                        RemoveNodeAndBalanceTree(nodeForRemoval: curNode, isNodeForRemovalNull: true);

                        curNode.Invalidate();
                    }

                    Count--;

                }
            }

        }
        //балансировка
        private void RemoveNodeAndBalanceTree(RedBlackTreeNode<T> nodeForRemoval, bool isNodeForRemovalNull)
        {
            RedBlackTreeNode<T> child;
            bool isChildNull;

            if (nodeForRemoval == Root)
            {
                Root = null;
                return;
            }

            if (!isNodeForRemovalNull)
            {
                if (nodeForRemoval.Left != null)
                {
                    isChildNull = false;
                    child = nodeForRemoval.Left;

                    if (nodeForRemoval.Parent.Left == nodeForRemoval)
                        nodeForRemoval.Parent.Left = child;
                    else
                        nodeForRemoval.Parent.Right = child;

                    child.Parent = nodeForRemoval.Parent;


                    if (child.IsRed || nodeForRemoval.IsRed)
                    {
                        child.IsRed = false;
                        return;
                    }
                }
                else if (nodeForRemoval.Right != null)
                {
                    isChildNull = false;
                    child = nodeForRemoval.Right;

                    if (nodeForRemoval.Parent.Left == nodeForRemoval)
                        nodeForRemoval.Parent.Left = child;
                    else
                        nodeForRemoval.Parent.Right = child;

                    child.Parent = nodeForRemoval.Parent;


                    if (child.IsRed || nodeForRemoval.IsRed)
                    {
                        child.IsRed = false;
                        return;
                    }
                }
                else
                {

                    if (nodeForRemoval.IsRed)
                    {

                        if (nodeForRemoval.Parent.Left == nodeForRemoval)
                            nodeForRemoval.Parent.Left = null;
                        else
                            nodeForRemoval.Parent.Right = null;

                        nodeForRemoval.Parent = null;
                        return;
                    }

                    isChildNull = true;
                    child = nodeForRemoval;
                    child.IsRed = false;
                }
            }
            else
            {
                isChildNull = true;
                child = nodeForRemoval;
                child.IsRed = false;
            }



            var curNode = child;
            bool isCurNodeDoubleBlack = true;


            while (isCurNodeDoubleBlack && curNode != Root)
            {
                RedBlackTreeNode<T> sibling;
                bool siblingIsLeftChild;
                if (curNode.Parent.Left == curNode)
                {
                    sibling = curNode.Parent.Right;
                    siblingIsLeftChild = false;
                }
                else
                {
                    sibling = curNode.Parent.Left;
                    siblingIsLeftChild = true;
                }


                if (sibling == null)

                {
                    if (curNode.Parent.IsRed)
                    {
                        curNode.Parent.IsRed = false;
                        isCurNodeDoubleBlack = false;
                    }
                    else
                    {
                        curNode = curNode.Parent;
                    }
                }
                else if (!sibling.IsRed)
                {
                    var leftChildIsRed = sibling.Left?.IsRed ?? false;
                    var rightchildIsRed = sibling.Right?.IsRed ?? false;



                    if (leftChildIsRed || rightchildIsRed)
                    {

                        if (siblingIsLeftChild)
                        {
                            if (rightchildIsRed && !leftChildIsRed)
                            {
                                RotateLeft(sibling);
                                RotateRight(curNode.Parent);
                            }
                            else
                            {
                                RotateRight(curNode.Parent);
                            }
                        }
                        else
                        {
                            if (leftChildIsRed && !rightchildIsRed)
                            {
                                RotateRight(sibling);
                                RotateLeft(curNode.Parent);
                            }
                            else
                            {
                                RotateLeft(curNode.Parent);
                            }
                        }


                        isCurNodeDoubleBlack = false;
                    }
                    else
                    {

                        sibling.IsRed = true;


                        if (curNode.Parent.IsRed)
                        {
                            curNode.Parent.IsRed = false;
                            isCurNodeDoubleBlack = false;
                        }
                        else
                        {
                            curNode = curNode.Parent;
                        }


                        if (isChildNull)
                        {
                            if (child.Parent.Left == child)
                                child.Parent.Left = null;
                            else
                                child.Parent.Right = null;

                            child.Invalidate();

                            isChildNull = false;
                        }
                    }

                }
                else
                {

                    sibling.IsRed = false;
                    curNode.Parent.IsRed = true;

                    if (siblingIsLeftChild)
                    {
                        RotateRight(curNode.Parent);
                    }
                    else
                    {
                        RotateLeft(curNode.Parent);
                    }
                }
            }


            if (isChildNull)
            {
                if (child.Parent.Left == child)
                    child.Parent.Left = null;
                else
                    child.Parent.Right = null;

                child.Invalidate();
            }
        }
        #endregion
        /// <summary>
        /// Определяет наличие значения в дереве <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно проверить.</param>
        /// <returns>true если дерево содержит данное значение, иначе false.</returns>
        public override bool Contains(T value)
        {
            return base.Contains(value);
        }

        /// <summary>
        /// Удаляет элементы из <see cref="RedBlackTree{T}"/>.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// Итератор дерева <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <returns>Возвращает элементы все элементы дерева согласно методу обхода в ширину</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
        #region
        public override Image Print(PictureBox image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Paint(graphics, Root, image.Width / 2, 50, 1);
            return bmp;
        }
        private void Paint(Graphics graphics, RedBlackTreeNode<T> node, int x, int y, int level)
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

        private void DrawRect(RedBlackTreeNode<T> node, int x, int y, Graphics graphics)
        {
            if (node != null)
            {
                Rectangle rect;
                rect = new Rectangle(x, y, 50, 50);
                if (node.IsRed)
                {
                    graphics.FillEllipse(Brushes.Red, rect);
                    graphics.DrawEllipse(Pens.Black, rect);
                    TextRenderer.DrawText(graphics, node.Value.ToString(), new Font("Times New Roman", 12.0f), rect, Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    graphics.FillEllipse(Brushes.Black, rect);
                    TextRenderer.DrawText(graphics, node.Value.ToString(), new Font("Times New Roman", 12.0f), rect, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
        #endregion
    }
}
