using M31.BinarySearchTrees;

// ReSharper disable UnusedVariable

CreationViaBuilder();
CreationViaProperties();
CreationViaConstructor();
CreationViaConstructorWithValues();
Rebalancing();
RangeSearch();
TreeTraversals();
Stringification();

static void CreationViaBuilder()
{
    BinarySearchTree<int> tree = TreeBuilder<int>
        .BuildTree(2, b => b
            .Left(1)
            .Right(4, b => b
                .Left(3)
                .Right(5)));
}

static void CreationViaProperties()
{
    Node<int> root = new(2)
    {
        Left = new(1),
        Right = new(4)
        {
            Left = new(3),
            Right = new(5)
        }
    };

    BinarySearchTree<int> tree = new BinarySearchTree<int>(root);
}

static void CreationViaConstructor()
{
    BinarySearchTree<int> tree = new BinarySearchTree<int>();
    tree.Insert(1);
    tree.Insert(2);
    // ...
}

static void CreationViaConstructorWithValues()
{
    BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 1, 2, 3, 4, 5 });
}

static void Rebalancing()
{
    BinarySearchTree<int> tree = TreeBuilder<int>
        .BuildTree(3, b => b
            .Left(2, b => b
                .Left(1)));

    tree.Rebalance();

    // Root = 2, Left = 1, Right = 3
}

static void RangeSearch()
{
    BinarySearchTree<int> tree = TreeBuilder<int>
        .BuildTree(2, b => b
            .Left(1)
            .Right(4, b => b
                .Left(3)
                .Right(5)));

    IEnumerable<Node<int>> range1 = tree.GetNodesLessThanOrEqual(4); // 1, 2, 3, 4
    var range2 = tree.GetNodesGreaterThan(3); // 4, 5
    var range3 = tree.GetNodesGreaterThanOrEqual(3); // 3, 4, 5
    var range4 = tree.GetNodesInRange(2, 5); // 2, 3, 4, 5
    var range5 = tree.GetNodesInRange(2, 5, excludeLower: true, excludeUpper: true); // 3, 4
}

static void TreeTraversals()
{
    BinarySearchTree<int> tree = TreeBuilder<int>
        .BuildTree(5, b => b
            .Left(4, b => b
                .Left(3))
            .Right(7, b => b
                .Left(6)
                .Right(8)));

    IEnumerable<Node<int>> inOrder = tree.Root.InOrderTraversal(); // 3, 4, 5, 6, 7, 8
    var preOrder = tree.Root.PreOrderTraversal(); // 5, 4, 3, 7, 6, 8
    var postOrder = tree.Root.PostOrderTraversal(); // 3, 4, 6, 8, 7, 5
    var breadthFirstOrder = tree.Root.BreadthFirstSearch(); // 5, 4, 7, 3, 6, 8
}

static void Stringification()
{
    BinarySearchTree<int> tree = TreeBuilder<int>
        .BuildTree(2, b => b
            .Left(1)
            .Right(4, b => b
                .Left(3)
                .Right(5)));

    string treeString = tree.Root.TreeString(); // "(2(1(null)(null))(4(3(null)(null))(5(null)(null))))"
    var inOrderTraversalString = tree.Root.InOrderTraversalString(); // "1-2-3-4-5"
    var preOrderTraversalString = tree.Root.PreOrderTraversalString(); // "2-1-4-3-5"
    var postOrderTraversalString = tree.Root.PostOrderTraversalString(); // "1-3-5-4-2"
}