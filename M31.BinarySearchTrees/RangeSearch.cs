namespace M31.BinarySearchTrees;

/// <summary>
/// This class provides range search funcitonality in the form of binary
/// search tree extension methods.
/// </summary>
public static class RangeSearch
{
    /// <summary>
    /// Gets all nodes between a lower and an upper bound.
    /// The elements are ordered and yield returned one at a time.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <param name="lower">The lower bound.</param>
    /// <param name="upper">The upper bound.</param>
    /// <param name="excludeLower">Indicates whether the lower bound should be excluded (open interval).</param>
    /// <param name="excludeUpper">Indicates whether the upper bound should be excluded (open interval).</param>
    /// <returns>The ordered nodes in the given range.</returns>
    public static IEnumerable<Node<T>> GetNodesInRange<T>(
        this BinarySearchTree<T> tree,
        T lower,
        T upper,
        bool excludeLower = false,
        bool excludeUpper = false)
    {
        if (tree.Root == null || tree.Comparer.Compare(lower, upper) > 0)
        {
            yield break;
        }

        Node<T>? current = tree.Root;

        while (current != null)
        {
            int compared1 = tree.Comparer.Compare(lower, current.Value);
            int compared2 = tree.Comparer.Compare(upper, current.Value);

            if (compared1 != compared2)
            {
                foreach (Node<T> node in GetNodesGreaterThan(new BinarySearchTree<T>(current.Left, tree.Comparer), lower, excludeLower))
                {
                    yield return node;
                }

                if (compared1 == 0)
                {
                    if (!excludeLower)
                    {
                        yield return current;
                    }
                }
                else if (compared2 == 0)
                {
                    if (!excludeUpper)
                    {
                        yield return current;
                    }
                }
                else
                {
                    yield return current;
                }

                foreach (Node<T> node in GetNodesLessThan(new BinarySearchTree<T>(current.Right, tree.Comparer), upper, excludeUpper))
                {
                    yield return node;
                }

                break;
            }

            if (compared1 < 0) // compared2 < 0 as well
            {
                current = current.Left;
            }
            else if (compared1 > 0) // compared2 > 0 as well
            {
                current = current.Right;
            }
            else // compared1 == compared2 => lower == upper
            {
                if (!excludeUpper && !excludeLower)
                {
                    yield return current;
                }

                yield break;
            }
        }
    }

    /// <summary>
    /// Gets all nodes that have values less than a specified upper bound.
    /// The elements are ordered and yield returned one at a time.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <param name="upper">The upper bound.</param>
    /// <returns>The ordered nodes with values less than the given upper bound.</returns>
    public static IEnumerable<Node<T>> GetNodesLessThan<T>(this BinarySearchTree<T> tree, T upper)
    {
        return GetNodesLessThan(tree, upper, excludeUpper: true);
    }

    /// <summary>
    /// Gets all nodes that have values less than or equal a specified upper bound.
    /// The elements are ordered and yield returned one at a time.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <param name="upper">The upper bound.</param>
    /// <returns>The ordered nodes with values less than or equal the given upper bound.</returns>
    public static IEnumerable<Node<T>> GetNodesLessThanOrEqual<T>(this BinarySearchTree<T> tree, T upper)
    {
        return GetNodesLessThan(tree, upper, excludeUpper: false);
    }

    private static IEnumerable<Node<T>> GetNodesLessThan<T>(this BinarySearchTree<T> tree, T upper, bool excludeUpper = false)
    {
        Node<T>? current = tree.Root;

        while (current != null)
        {
            int compared = tree.Comparer.Compare(upper, current.Value);

            if (compared < 0)
            {
                current = current.Left;
            }
            else if (compared > 0)
            {
                foreach (Node<T> node in current.Left.InOrderTraversal())
                {
                    yield return node;
                }

                yield return current;

                current = current.Right;
            }
            else
            {
                foreach (Node<T> node in current.Left.InOrderTraversal())
                {
                    yield return node;
                }

                if (!excludeUpper)
                {
                    yield return current;
                }

                break;
            }
        }
    }

    /// <summary>
    /// Gets all nodes that have values greater than a specified lower bound.
    /// The elements are ordered and yield returned one at a time.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <param name="lower">The lower bound.</param>
    /// <returns>The ordered nodes with values greater than the given lower bound.</returns>
    public static IEnumerable<Node<T>> GetNodesGreaterThan<T>(this BinarySearchTree<T> tree, T lower)
    {
        return GetNodesGreaterThan(tree, lower, excludeLower: true);
    }

    /// <summary>
    /// Gets all nodes that have values greater than or equal a specified lower bound.
    /// The elements are ordered and yield returned one at a time.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="tree">The tree.</param>
    /// <param name="lower">The lower bound.</param>
    /// <returns>The ordered nodes with values greater than or equal the given lower bound.</returns>
    public static IEnumerable<Node<T>> GetNodesGreaterThanOrEqual<T>(this BinarySearchTree<T> tree, T lower)
    {
        return GetNodesGreaterThan(tree, lower, excludeLower: false);
    }

    private static IEnumerable<Node<T>> GetNodesGreaterThan<T>(BinarySearchTree<T> tree, T lower, bool excludeLower = false)
    {
        List<Node<T>> largerNodes = new List<Node<T>>();

        Node<T>? equalNode = null;
        Node<T>? current = tree.Root;

        while (current != null)
        {
            int compared = tree.Comparer.Compare(lower, current.Value);

            if (compared < 0)
            {
                largerNodes.Add(current);
                current = current.Left;
            }
            else if (compared > 0)
            {
                current = current.Right;
            }
            else
            {
                equalNode = current;
                break;
            }
        }

        if (equalNode != null && !excludeLower)
        {
            yield return equalNode;
        }

        foreach (Node<T> largerNode in (largerNodes as IEnumerable<Node<T>>).Reverse())
        {
            yield return largerNode;

            foreach (Node<T> node in largerNode.Right.InOrderTraversal())
            {
                yield return node;
            }
        }
    }
}
