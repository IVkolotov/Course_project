namespace BinarySearchTree
{
    /// <summary>
    /// Представляет вершину в дереве <see cref="BinTree{T}"/>.
    /// </summary>
    internal class BinTreeNode<T>
    {
        /// <summary>
        /// Левый потомок <see cref="BinTreeNode{T}"/>.
        /// </summary>
        public BinTreeNode<T> Left { get; internal set; }

        /// <summary>
        /// Правый потомок <see cref="BinTreeNode{T}"/>.
        /// </summary>
        public BinTreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Значение вершины <see cref="BinTreeNode{T}"/>.
        /// </summary>
        public virtual T Value { get; internal set; }

        /// <summary>
        /// Конструктор <see cref="BinTreeNode{T}"/> класса, содержащее определенное значение.
        /// </summary>
        /// <param name="value">Значение, которое дожно храниться в вершине <see cref="BinTreeNode{T}"/>.</param>
        public BinTreeNode(T value)
        {
            Value = value;
        }
        public BinTreeNode()
        {
        }
        /// <summary>
        /// Удаляет всех потомков в <see cref="BinTreeNode{T}"/>.
        /// </summary>
        internal virtual void Invalidate()
        {
            Left = null;
            Right = null;
        }
    }
}
