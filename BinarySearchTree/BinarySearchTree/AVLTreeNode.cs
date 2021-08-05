namespace BinarySearchTree
{
    /// <summary>
    /// Представляет вершину в дереве <see cref="AVLTree{T}"/>.
    /// </summary>
    internal class AVLTreeNode<T> : BinTreeNode<T>
    {
        /// <summary>
        /// Левый потомок <see cref="AVLTreeNode{T}"/>.
        /// </summary>
        public new AVLTreeNode<T> Left
        {
            get { return (AVLTreeNode<T>)base.Left; }
            internal set { base.Left = value; }
        }
        /// <summary>
        /// Правый потомок <see cref="AVLTreeNode{T}"/>.
        /// </summary>
        public new AVLTreeNode<T> Right
        {
            get { return (AVLTreeNode<T>)base.Right; }
            internal set { base.Right = value; }
        }

        /// <summary>
        /// Значение вершины <see cref="AVLTreeNode{T}"/>.
        /// </summary>
        public override T Value { get; internal set; }

        /// <summary>
        /// Высота вершины <see cref="AVLTreeNode{T}"/>.
        /// </summary>
        public int Height { get; internal set; }

        /// <summary>
        /// Конструктор <see cref="AVLTreeNode{T}"/> класса, содержащее определенное значение.
        /// </summary>
        /// <param name="value">Значение, которое дожно храниться в вершине <see cref="AVLTreeNode{T}"/>.</param>
        public AVLTreeNode(T value) : base(value)
        {
            Value = value;
            Height = 1;
        }
    }
}
