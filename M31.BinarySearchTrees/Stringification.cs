using System.Text;

namespace M31.BinarySearchTrees;

/// <summary>
/// Node tree extensions methods for string serialization.
/// </summary>
public static class Stringification
{
    /// <summary>
    /// Transforms a node tree to a string representation.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <returns>The string representation.</returns>
    public static string ToTreeString<T>(this Node<T>? tree)
    {
        StringBuilder sb = new StringBuilder();
        tree.DepthFirstTraversalNullNodesIncluded(n => sb.Append($"({(n != null ? n.Value : "null")}"), null, n => sb.Append(')'));
        return sb.ToString();
    }

    /// <summary>
    /// Transforms a node tree to an in-order string representation.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <returns>The string representations of the values joined with dashes.</returns>
    public static string InOrderTraversalString<T>(this Node<T>? tree)
    {
        return string.Join("-", tree.InOrderTraversal().Select(n => n.Value));
    }

    /// <summary>
    /// Transforms a node tree to an pre-order string representation.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <returns>The string representations of the values joined with dashes.</returns>
    public static string PreOrderTraversalString<T>(this Node<T>? tree)
    {
        return string.Join("-", tree.PreOrderTraversal().Select(n => n.Value));
    }

    /// <summary>
    /// Transforms a node tree to an post-order string representation.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <returns>The string representations of the values joined with dashes.</returns>
    public static string PostOrderTraversalString<T>(this Node<T>? tree)
    {
        return string.Join("-", tree.PostOrderTraversal().Select(n => n.Value));
    }
}
