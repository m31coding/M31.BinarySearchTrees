namespace M31.BinarySearchTrees;

/// <summary>
/// A search tree node. Stores a value as well as references to its parent, left node, and right node.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public class Node<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Node(T value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Gets or sets the parent node.
    /// </summary>
    public Node<T>? Parent { get; set; }

    /// <summary>
    /// Gets or sets the left child node.
    /// </summary>
    public Node<T>? Left { get; set; }

    /// <summary>
    /// Gets or sets the right child node.
    /// </summary>
    public Node<T>? Right { get; set; }

    /// <inheritdoc/>
    public override string? ToString()
    {
        return Value?.ToString();
    }
}
