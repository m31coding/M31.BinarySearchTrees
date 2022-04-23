using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace M31.BinarySearchTrees.Tests;

[TestClass]
public class TraversalTests
{
    private static Node<int>?[] trees = null!;

    [ClassInitialize]
    public static void Initialize(TestContext context)
    {
        trees = new Node<int>?[3];

        trees[0] = null;

        trees[1] = TreeBuilder<int>
            .BuildNodes(5, b => b
                    .Left(4, b => b
                        .Left(3)));

        trees[2] = TreeBuilder<int>
            .BuildNodes(5, b => b
                    .Left(4, b => b
                        .Left(3))
                    .Right(7, b => b
                        .Left(6)
                        .Right(8)));
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("3-4-5", 1)]
    [DataRow("3-4-5-6-7-8", 2)]
    public void InOrderTraversalTest(string expected, int tree)
    {
        string actual = NodesToString(trees[tree].InOrderTraversal());
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("3-4-5", 1)]
    [DataRow("3-4-5-6-7-8", 2)]
    public void InOrderTraversalOnVisitTest(string expected, int tree)
    {
        StringBuilder sb = new StringBuilder();
        trees[tree].InOrderTraversal(n => AppendNodeAsString(sb, n));
        string actual = sb.ToString();
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("5-4-3", 1)]
    [DataRow("5-4-3-7-6-8", 2)]
    public void PreOrderTraversalTest(string expected, int tree)
    {
        string actual = NodesToString(trees[tree].PreOrderTraversal());
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("5-4-3", 1)]
    [DataRow("5-4-3-7-6-8", 2)]
    public void PreOrderTraversalOnVisitTest(string expected, int tree)
    {
        StringBuilder sb = new StringBuilder();
        trees[tree].PreOrderTraversal(n => AppendNodeAsString(sb, n));
        string actual = sb.ToString();
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("3-4-5", 1)]
    [DataRow("3-4-6-8-7-5", 2)]
    public void PostOrderTraversalTest(string expected, int tree)
    {
        string actual = NodesToString(trees[tree].PostOrderTraversal());
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("3-4-5", 1)]
    [DataRow("3-4-6-8-7-5", 2)]
    public void PostOrderTraversalOnVisitTest(string expected, int tree)
    {
        StringBuilder sb = new StringBuilder();
        trees[tree].PostOrderTraversal(n => AppendNodeAsString(sb, n));
        string actual = sb.ToString();
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("5-4-3", 1)]
    [DataRow("5-4-7-3-6-8", 2)]
    public void BreadthFirstSearchTest(string expected, int tree)
    {
        string actual = NodesToString(trees[tree].BreadthFirstSearch());
        Assert.AreEqual(expected, actual);
    }

    private static string NodesToString(IEnumerable<Node<int>> nodes)
    {
        return string.Join("-", nodes.Select(n => n.Value.ToString()));
    }

    private static void AppendNodeAsString(StringBuilder sb, Node<int> node)
    {
        sb.Append(sb.Length == 0 ? node.Value.ToString() : $"-{node.Value}");
    }
}
