namespace M31.BinarySearchTrees;

/// <summary>
/// A binary search tree.
/// </summary>
/// <typeparam name="T">The type of the node values.</typeparam>
public class BinarySearchTree<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// that is empty and uses the default equality comparer for the node values.
    /// </summary>
    public BinarySearchTree()
    {
        Root = null;
        Comparer = Comparer<T>.Default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// with the specified root and that uses the default equality comparer for the node values.
    /// </summary>
    /// <param name="root">The root node.</param>
    public BinarySearchTree(Node<T>? root)
       : this(root, Comparer<T>.Default)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// that is empty and uses the specified equality comparer for the node values.
    /// </summary>
    /// <param name="comparer">The value comparer.</param>
    public BinarySearchTree(IComparer<T> comparer)
    {
        Root = null;
        Comparer = comparer;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// with the specified root and that uses the specified equality comparer for the node values.
    /// </summary>
    /// <param name="root">The root node.</param>
    /// <param name="comparer">The value comparer.</param>
    public BinarySearchTree(Node<T>? root, IComparer<T> comparer)
    {
        Root = root;
        Comparer = comparer;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// with nodes that are created from the specified collection
    /// and that uses the default equality comparer for the node values.
    /// The result is a balanced tree.
    /// </summary>
    /// <param name="values">The values to insert.</param>
    public BinarySearchTree(IEnumerable<T> values)
        : this(values, Comparer<T>.Default)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class
    /// with nodes that are created from the specified collection
    /// and that uses the specified equality comparer for the node values.
    /// The result is a balanced tree.
    /// </summary>
    /// <param name="values">The values to insert.</param>
    /// <param name="comparer">The value comparer.</param>
    public BinarySearchTree(IEnumerable<T> values, IComparer<T> comparer)
    {
        Comparer = comparer;
        Root = Balancing.GetBalancedTree(values.Select(v => new Node<T>(v)), comparer);
    }

    /// <summary>
    /// Gets or sets the root of the tree.
    /// </summary>
    public Node<T>? Root { get; set; }

    /// <summary>
    /// Gets the value comparer.
    /// </summary>
    public IComparer<T> Comparer { get; }

    /// <summary>
    /// Searches the node with the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The node that has been found or null.</returns>
    public Node<T>? Search(T value)
    {
        Node<T>? current = Root;

        while (current != null)
        {
            int compared = Comparer.Compare(value, current.Value);

            if (compared < 0)
            {
                current = current.Left;
            }
            else if (compared > 0)
            {
                current = current.Right;
            }
            else
            {
                return current;
            }
        }

        return current;
    }

    /// <summary>
    /// Searches for the node with the maximum value.
    /// </summary>
    /// <returns>The maximum value node.</returns>
    public Node<T>? Maximum()
    {
        return Root?.Maximum();
    }

    /// <summary>
    /// Searches for the node with the minimum value.
    /// </summary>
    /// <returns>The minimum value node.</returns>
    public Node<T>? Minimum()
    {
        return Root?.Minimum();
    }

    /// <summary>
    /// Inserts the node with the specified value.
    /// The same value must not be inserted twice into the tree.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentException">The value already exists.</exception>
    public void Insert(T value)
    {
        Insert(new Node<T>(value));
    }

    /// <summary>
    /// Inserts a new node into the tree.
    /// A node with an already existing value must not be inserted into the tree.
    /// </summary>
    /// <param name="node">The node.</param>
    /// <exception cref="ArgumentException">The value of the node already exists.</exception>
    public void Insert(Node<T> node)
    {
        Node<T>? parent = null;
        Node<T>? current = Root;

        while (current != null)
        {
            parent = current;
            int compared = Comparer.Compare(node.Value, current.Value);
            if (compared < 0)
            {
                current = current.Left;
            }
            else if (compared > 0)
            {
                current = current.Right;
            }
            else
            {
                throw new ArgumentException($"A node with value {node.Value} already exists!");
            }
        }

        node.Parent = parent;

        if (parent == null)
        {
            Root = node;
        }
        else if (Comparer.Compare(node.Value, parent.Value) < 0)
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }
    }

    /// <summary>
    /// Deletes the node with the given value from the tree.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Whether the value was found and deleted.</returns>
    public bool Delete(T value)
    {
        if (Root == null)
        {
            return false;
        }

        Node<T>? node = Search(value);

        if (node != null)
        {
            Delete(node);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Deletes the given node from the tree.
    /// The node must exist in the tree.
    /// </summary>
    /// <param name="node">A node that is present in the tree.</param>
    public void Delete(Node<T> node)
    {
        if (node.Left == null)
        {
            Replace(node, node.Right);
        }
        else if (node.Right == null)
        {
            Replace(node, node.Left);
        }
        else
        {
            Node<T> successor = node.Successor()!;

            if (successor.Parent != node)
            {
                Replace(successor, successor.Right);
                successor.Right = node.Right;
                successor.Right.Parent = successor;
            }

            Replace(node, successor);
            successor.Left = node.Left;
            successor.Left.Parent = successor;
        }
    }

    /// <summary>
    /// Replaces a node in the tree with another node.
    /// The former node must exist in the tree.
    /// </summary>
    /// <param name="node">The node to replace.</param>
    /// <param name="replacement">The new node.</param>
    public void Replace(Node<T> node, Node<T>? replacement)
    {
        if (node.Parent == null)
        {
            Root = replacement;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = replacement;
        }
        else
        {
            node.Parent.Right = replacement;
        }

        if (replacement != null)
        {
            replacement.Parent = node.Parent;
        }
    }

    /// <summary>
    /// Implicit conversion from the tree to the root node.
    /// </summary>
    /// <param name="tree">The tree.</param>
    public static implicit operator Node<T>?(BinarySearchTree<T> tree)
    {
        return tree.Root;
    }
}
