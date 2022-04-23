namespace M31.BinarySearchTrees;

/// <summary>
/// Methods for balancing a tree.
/// </summary>
public static class Balancing
{
    /// <summary>
    /// Rebalances a binary search tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The tree.</param>
    public static void Rebalance<T>(this BinarySearchTree<T> tree)
    {
        Node<T>[] sortedNodes = tree.Root.InOrderTraversal().ToArray();
        tree.Root = GetBalancedTreeFromSortedNodes(sortedNodes);
    }

    /// <summary>
    /// Creates a balanced node tree from the provided nodes.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="nodes">The nodes.</param>
    /// <param name="comparer">Comparer for the values.</param>
    /// <returns>A balanced node tree.</returns>
    public static Node<T>? GetBalancedTree<T>(IEnumerable<Node<T>> nodes, IComparer<T>? comparer = null)
    {
        comparer ??= Comparer<T>.Default;
        Node<T>[] sortedNodes = nodes.ToArray();
        Array.Sort(sortedNodes, (n1, n2) => comparer.Compare(n1.Value, n2.Value));
        Node<T>? root = GetBalancedTreeFromSortedNodes(sortedNodes);
        return new BinarySearchTree<T>(root, comparer);
    }

    /// <summary>
    /// Create as balanced node tree from sorted nodes.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="sortedNodes">The sorted nodes.</param>
    /// <returns>A balanced node tree.</returns>
    public static Node<T>? GetBalancedTreeFromSortedNodes<T>(IList<Node<T>> sortedNodes)
    {
        return GetBalancedTree(sortedNodes, 0, sortedNodes.Count - 1);
    }

    private static Node<T>? GetBalancedTree<T>(IList<Node<T>> sortedNodes, int start, int end)
    {
        if (start > end)
        {
            return null;
        }

        int mid = (start + end) / 2;
        Node<T> node = sortedNodes[mid];
        node.Left = GetBalancedTree(sortedNodes, start, mid - 1);
        node.Right = GetBalancedTree(sortedNodes, mid + 1, end);
        return node;
    }
}
