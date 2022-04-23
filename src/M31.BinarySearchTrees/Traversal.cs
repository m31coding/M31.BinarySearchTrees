namespace M31.BinarySearchTrees;

/// <summary>
/// Methods for traversing a node tree.
/// </summary>
public static class Traversal
{
    /// <summary>
    /// In-order traversal of the tree. Makes use of a stack and yield returns one element at a time.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The traversed nodes.</returns>
    public static IEnumerable<Node<T>> InOrderTraversal<T>(this Node<T>? tree)
    {
        if (tree == null)
        {
            yield break;
        }

        Stack<Node<T>> stack = new Stack<Node<T>>();
        Node<T>? current = tree;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            yield return current;
            current = current.Right;
        }
    }

    /// <summary>
    /// Pre-order traversal of the tree. Makes use of a stack and yield returns one element at a time.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The traversed nodes.</returns>
    public static IEnumerable<Node<T>> PreOrderTraversal<T>(this Node<T>? tree)
    {
        if (tree == null)
        {
            yield break;
        }

        Stack<Node<T>> stack = new Stack<Node<T>>();
        stack.Push(tree);

        while (stack.Count > 0)
        {
            Node<T> current = stack.Pop();
            yield return current;

            if (current.Right != null)
            {
                stack.Push(current.Right);
            }

            if (current.Left != null)
            {
                stack.Push(current.Left);
            }
        }
    }

    /// <summary>
    /// Post-order traversal of the tree. Makes use of two stacks and yield returns one element at a time.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The traversed nodes.</returns>
    public static IEnumerable<Node<T>> PostOrderTraversal<T>(this Node<T>? tree)
    {
        Stack<Node<T>> stack1 = new Stack<Node<T>>();
        Stack<Node<T>> stack2 = new Stack<Node<T>>();

        if (tree == null)
        {
            yield break;
        }

        stack1.Push(tree);

        while (stack1.Count > 0)
        {
            Node<T> current = stack1.Pop();
            stack2.Push(current);

            if (current.Left != null)
            {
                stack1.Push(current.Left);
            }

            if (current.Right != null)
            {
                stack1.Push(current.Right);
            }
        }

        foreach (Node<T> node in stack2)
        {
            yield return node;
        }
    }

    /// <summary>
    /// In-order traversal of the tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <param name="onVisit">Action that will be executed when a node is visited.</param>
    public static void InOrderTraversal<T>(this Node<T>? tree, Action<Node<T>> onVisit)
    {
        if (tree == null)
        {
            return;
        }

        InOrderTraversal(tree.Left, onVisit);
        onVisit(tree);
        InOrderTraversal(tree.Right, onVisit);
    }

    /// <summary>
    /// Pre-order traversal of the tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <param name="onVisit">Action that will be executed when a node is visited.</param>
    public static void PreOrderTraversal<T>(this Node<T>? tree, Action<Node<T>> onVisit)
    {
        if (tree == null)
        {
            return;
        }

        onVisit(tree);
        PreOrderTraversal(tree.Left, onVisit);
        PreOrderTraversal(tree.Right, onVisit);
    }

    /// <summary>
    /// Post-order traversal of the tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <param name="onVisit">Action that will be executed when a node is visited.</param>
    public static void PostOrderTraversal<T>(this Node<T>? tree, Action<Node<T>> onVisit)
    {
        if (tree == null)
        {
            return;
        }

        PostOrderTraversal(tree.Left, onVisit);
        PostOrderTraversal(tree.Right, onVisit);
        onVisit(tree);
    }

    /// <summary>
    /// Depth-first search (DFS) traversal of the tree.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <param name="onEnter">Action that will be executed when a node is entered.</param>
    /// <param name="onPass">Action that will be executed when a node is visited
    /// between the traversals of the left and right subtrees.</param>
    /// <param name="onExit">Action that will be executed when a node is exited.</param>
    public static void DepthFirstTraversal<T>(this Node<T>? tree,
        Action<Node<T>>? onEnter,
        Action<Node<T>>? onPass,
        Action<Node<T>>? onExit)
    {
        if (tree == null)
        {
            return;
        }

        onEnter?.Invoke(tree);
        DepthFirstTraversal(tree.Left, onEnter, onPass, onExit);
        onPass?.Invoke(tree);
        DepthFirstTraversal(tree.Right, onEnter, onPass, onExit);
        onExit?.Invoke(tree);
    }

    /// <summary>
    /// Depth-first search (DFS) traversal of the tree including Null-nodes.
    /// In particular, empty trees are visited, as well as empty children of tree nodes.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <param name="onEnter">Action that will be executed when a node is entered.</param>
    /// <param name="onPass">Action that will be executed when a node is visited
    /// between the traversals of the left and right subtrees.</param>
    /// <param name="onExit">Action that will be executed when a node is exited.</param>
    public static void DepthFirstTraversalNullNodesIncluded<T>(this Node<T>? tree,
        Action<Node<T>?>? onEnter,
        Action<Node<T>?>? onPass,
        Action<Node<T>?>? onExit)
    {
        onEnter?.Invoke(tree);

        if (tree != null)
        {
            DepthFirstTraversalNullNodesIncluded(tree.Left, onEnter, onPass, onExit);
        }

        onPass?.Invoke(tree);

        if (tree != null)
        {
            DepthFirstTraversalNullNodesIncluded(tree.Right, onEnter, onPass, onExit);
        }

        onExit?.Invoke(tree);
    }

    /// <summary>
    /// Breadth-first search (BFS) for the tree. Makes use of a queue and yield returns one element at a time.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="tree">The node tree.</param>
    /// <returns>The nodes in BFS-order.</returns>
    public static IEnumerable<Node<T>> BreadthFirstSearch<T>(this Node<T>? tree)
    {
        if (tree == null)
        {
            yield break;
        }

        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(tree);

        while (queue.Count > 0)
        {
            Node<T> current = queue.Dequeue();
            yield return current;

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }
}
