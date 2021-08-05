using System;

namespace BinarySearchTree
{
    /// <summary>
    /// Представляет вершину в дереве <see cref="RedBlackTree{T}"/>.
    /// </summary>
    internal class RedBlackTreeNode<T> : BinTreeNode<T>
    {
        /// <summary>
        /// Левый потомок the <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public new RedBlackTreeNode<T> Left
        {
            get { return (RedBlackTreeNode<T>)base.Left; }
            internal set { base.Left = value; }
        }

        /// <summary>
        /// Правый потомок <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public new RedBlackTreeNode<T> Right
        {
            get { return (RedBlackTreeNode<T>)base.Right; }
            internal set { base.Right = value; }
        }

        /// <summary>
        /// Предок <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public RedBlackTreeNode<T> Parent { get; internal set; }

        /// <summary>
        /// Значение вершины <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public override T Value { get; internal set; }

        /// <summary>
        /// Является ли вершина красной <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public bool IsRed { get; internal set; }

        /// <summary>
        /// Конструктор <see cref="RedBlackTreeNode{T}"/> класса, содержащее определенное значение.
        /// </summary>
        /// <param name="value">Значение, которое дожно храниться в вершине <see cref="RedBlackTreeNode{T}"/>.</param>
        public RedBlackTreeNode(T value) : base(value)
        {
            Value = value;
            IsRed = true;
            
        }

        /// <summary>
        /// Удаляет всех потомков в <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        internal override void Invalidate()
        {
            Left = null;
            Right = null;
            Parent = null;
        }

      
    }
}
