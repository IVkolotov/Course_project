using System;
using System.Collections.Generic;


namespace BinarySearchTree
{
    /// <summary>
    /// Представляет АВЛ Бинарное дерево поиска
    /// </summary>
    public class AVLTree<T> : BinTree<T>
        where T : IComparable<T>, IComparable
    {
        /// <summary>
        /// Корень дерева <see cref="AVLTree{T}"/>.
        /// </summary>
        internal new AVLTreeNode<T> Root
        {
            get { return (AVLTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        /// <summary>
        /// Количество элементов в дереве <see cref="AVLTree{T}"/>.
        /// </summary>
        public override int Count { get; internal set; }

        /// <summary>
        /// Создаёт новый экземпляр <see cref="AVLTree{T}"/>
        /// </summary>
        public AVLTree() : base() { }

        /// <summary>
        /// Высота поддерева в вершине <see cref="AVLTree{T}"/>
        /// </summary>
        private int NodeHeight(AVLTreeNode<T> node)
        {
            return node?.Height ?? 0;
        }

        /// <summary>
        /// Исправляет высоту вершины
        /// </summary>
        private void FixHeight(AVLTreeNode<T> node)
        {
            var leftHeight = NodeHeight(node.Left);
            var rightHeight = NodeHeight(node.Right);
            node.Height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
        }

        /// <summary>
        /// Подсчёт баланса
        /// </summary>
        private int BalanceFactor(AVLTreeNode<T> node)
        {
            return NodeHeight(node.Left) - NodeHeight(node.Right);
        }
        /// <summary>
        /// Левый поворот
        /// </summary>
        private AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> m = node.Right;
            node.Right = m.Left;
            m.Left = node;
            FixHeight(node);
            FixHeight(m);
            return m;
        }
        /// <summary>
        /// Правый поворот
        /// </summary>
        private AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> m = node.Left;
            node.Left = m.Right;
            m.Right = node;
            FixHeight(node);
            FixHeight(m);
            return m;
        }

        /// <summary>
        /// Балансировка дерева
        /// </summary>
        private AVLTreeNode<T> Balance(AVLTreeNode<T> node)
        {
            FixHeight(node);
            if (BalanceFactor(node) == -2)
            {
                if (BalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            if (BalanceFactor(node) == 2)
            {
                if (BalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node;
        }

        /// <summary>
        /// Добавляет элемент в <see cref="AVLTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение, которое нужно добавить.</param>
        public override void Add(T value)
        {
            Root = Add(Root, value);
            Count++;
        }
        public override void AddItems(IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Рекурсивное добавление вершины с балансировкой
        /// </summary>
        private AVLTreeNode<T> Add(AVLTreeNode<T> node, T value)
        {
            if (node == null) return new AVLTreeNode<T>(value);
            if (value.CompareTo(node.Value) < 0) node.Left = Add(node.Left, value);
            else if (value.CompareTo(node.Value) > 0) node.Right = Add(node.Right, value);
            return Balance(node);
        }

        /// <summary>
        /// Удаляет элемент из <see cref="AVLTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно удалить</param>
        public override void Remove(T value)
        {
            Root = Remove(Root, value);
        }

        /// <summary>
        ///  Рекурсивное удаление вершины с балансировкой
        /// </summary>
        private AVLTreeNode<T> Remove(AVLTreeNode<T> node, T value)
        {
            if (node == null) return node;
            if (value.CompareTo(node.Value) < 0) node.Left = Remove(node.Left, value);
            else if (value.CompareTo(node.Value) > 0) node.Right = Remove(node.Right, value);
            else
            {
                Count--;
                AVLTreeNode<T> left = node.Left;
                AVLTreeNode<T> right = node.Right;

                node.Invalidate();

                if (right == null) return left;

                AVLTreeNode<T> min = null;
                AVLTreeNode<T> rightSubtreeRoot = FindAndRemoveMin(right, ref min);
                min.Right = rightSubtreeRoot;
                min.Left = left;

                return Balance(min);
            }
            return Balance(node);
        }

        /// <summary>
        /// Удаление вершины с минимальным значением
        /// </summary>
        private AVLTreeNode<T> FindAndRemoveMin(AVLTreeNode<T> node, ref AVLTreeNode<T> min)
        {
            if (node.Left == null)
            {
                min = node;
                return node.Right;
            }
            node.Left = FindAndRemoveMin(node.Left, ref min);
            return Balance(node);
        }

        /// <summary>
        /// Определяет наличие значения в дереве <see cref="BinTree{T}"/>.
        /// </summary>
        /// <param name="value">Значение которое нужно проверить.</param>
        /// <returns>true если дерево содержит данное значение, иначе false.</returns>
        public override bool Contains(T value)
        {
            return base.Contains(value);
        }

        /// <summary>
        /// Очистка дерева <see cref="AVLTree{T}"/>.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// Итератор дерева <see cref="BinTree{T}"/>.
        /// </summary>
        /// <returns>Возвращает элементы все элементы дерева согласно методу обхода в ширину</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
