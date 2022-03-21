namespace M31.BinarySearchTrees;

/// <summary>
/// Factory methods for creating a binary search tree.
/// </summary>
public static class TreeFactory
{
    /// <summary>
    /// Creates a binary search tree from values.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="values">The values.</param>
    /// <param name="comparer">An optional comparer.</param>
    /// <returns>The binary search tree.</returns>
    public static BinarySearchTree<T> CreateTreeFromValues<T>(IEnumerable<T> values, IComparer<T>? comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        Node<T>? balancedTree = Balancing.GetBalancedTree(values.Select(v => new Node<T>(v)), comparer);
        return new BinarySearchTree<T>(balancedTree, comparer);
    }
}
