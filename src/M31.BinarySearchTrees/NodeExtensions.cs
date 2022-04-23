namespace M31.BinarySearchTrees;

/// <summary>
/// Essential node extension methods.
/// </summary>
public static class NodeExtensions
{
    /// <summary>
    /// Searches the maximum node in the node tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The node with the maximum value.</returns>
    public static Node<T> Maximum<T>(this Node<T> tree)
    {
        Node<T> current = tree;

        while (current.Right != null)
        {
            current = current.Right;
        }

        return current;
    }

    /// <summary>
    /// Searches the minimum node in the node tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The node with the minimum value.</returns>
    public static Node<T> Minimum<T>(this Node<T> tree)
    {
        Node<T> current = tree;

        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    /// <summary>
    /// Searches for the successor of a node.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="node">The node.</param>
    /// <returns>The successor node.</returns>
    public static Node<T>? Successor<T>(this Node<T> node)
    {
        if (node.Right != null)
        {
            return node.Right.Minimum();
        }

        Node<T>? current = node.Parent;

        while (current != null && node == current.Right)
        {
            node = current;
            current = current.Parent;
        }

        return current;
    }

    /// <summary>
    /// Searches for the predecessor of a node.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="node">The node.</param>
    /// <returns>The predecessor node.</returns>
    public static Node<T>? Predecessor<T>(Node<T> node)
    {
        if (node.Left != null)
        {
            return node.Left.Maximum();
        }

        Node<T>? current = node.Parent;

        while (current != null && node == current.Left)
        {
            node = current;
            current = current.Parent;
        }

        return current;
    }
}
