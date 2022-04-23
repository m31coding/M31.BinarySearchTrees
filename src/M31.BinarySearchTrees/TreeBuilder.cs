namespace M31.BinarySearchTrees;

/// <summary>
/// A builder for creating binary search trees.
/// </summary>
/// <typeparam name="T">The type of the values.</typeparam>
public class TreeBuilder<T>
{
    private readonly Node<T> node;

    private TreeBuilder(T value)
    {
        node = new Node<T>(value);
    }

    /// <summary>
    /// Build a node tree.
    /// </summary>
    /// <param name="value">The root value.</param>
    /// <param name="buildTree">Func for building the tree.</param>
    /// <returns>The node tree.</returns>
    public static Node<T> BuildNodes(T value, Func<TreeBuilder<T>, TreeBuilder<T>>? buildTree = null)
    {
        return buildTree == null ? new Node<T>(value) : buildTree(new TreeBuilder<T>(value)).node;
    }

    /// <summary>
    /// Build a binary search tree.
    /// </summary>
    /// <param name="value">The root value.</param>
    /// <param name="buildTree">Func for building the tree.</param>
    /// <returns>The binary search tree.</returns>
    public static BinarySearchTree<T> BuildTree(T value, Func<TreeBuilder<T>, TreeBuilder<T>>? buildTree = null)
    {
        return new BinarySearchTree<T>(BuildNodes(value, buildTree));
    }

    /// <summary>
    /// Build a binary search tree.
    /// </summary>
    /// <param name="comparer">Comparer for the values.</param>
    /// <param name="value">The root value.</param>
    /// <param name="buildTree">Func for building the tree.</param>
    /// <returns>The binary search tree.</returns>
    public static BinarySearchTree<T> BuildTree(IComparer<T> comparer, T value, Func<TreeBuilder<T>, TreeBuilder<T>>? buildTree = null)
    {
        return new BinarySearchTree<T>(BuildNodes(value, buildTree), comparer);
    }

    /// <summary>
    /// Set the left node of the current node.
    /// </summary>
    /// <param name="value">The value of the left node.</param>
    /// <param name="buildTree">Func for building the tree.</param>
    /// <returns>The tree builder.</returns>
    public TreeBuilder<T> Left(T value, Func<TreeBuilder<T>, TreeBuilder<T>>? buildTree = null)
    {
        node.Left = buildTree == null ? new Node<T>(value) : buildTree(new TreeBuilder<T>(value)).node;
        node.Left.Parent = node;
        return this;
    }

    /// <summary>
    /// Set the right node of the current node.
    /// </summary>
    /// <param name="value">The value of the right node.</param>
    /// <param name="buildTree">Func for building the tree.</param>
    /// <returns>The tree builder.</returns>
    public TreeBuilder<T> Right(T value, Func<TreeBuilder<T>, TreeBuilder<T>>? buildTree = null)
    {
        node.Right = buildTree == null ? new Node<T>(value) : buildTree(new TreeBuilder<T>(value)).node;
        node.Right.Parent = node;
        return this;
    }
}
