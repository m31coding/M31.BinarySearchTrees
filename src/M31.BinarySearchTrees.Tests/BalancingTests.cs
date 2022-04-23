using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M31.BinarySearchTrees.Tests;

[TestClass]
public class BalancingTests
{
    [TestMethod]
    public void CanBalanceTree()
    {
        BinarySearchTree<int> tree = TreeBuilder<int>
         .BuildTree(3, b => b
                .Left(2, b => b
                    .Left(1)));

        tree.Rebalance();
        string treeString = tree.Root.TreeString();
        Assert.AreEqual("(2(1(null)(null))(3(null)(null)))", treeString);
    }

    [TestMethod]
    public void CanGetBalancedTreeOfZeroNodes()
    {
        Node<int>? tree = Balancing.GetBalancedTree(Array.Empty<Node<int>>());
        string treeString = tree.TreeString();
        Assert.AreEqual("(null)", treeString);
    }

    [TestMethod]
    public void CanGetBalancedTreeOfThreeNodes()
    {
        Node<int>[] nodes = new int[] { 3, 1, 2 }.Select(v => new Node<int>(v)).ToArray();
        Node<int>? tree = Balancing.GetBalancedTree(nodes);
        string treeString = tree.TreeString();
        Assert.AreEqual("(2(1(null)(null))(3(null)(null)))", treeString);
    }

    [TestMethod]
    public void CanGetBalancedTreeOfSevenNodes()
    {
        Node<int>[] nodes = new int[] { 6, 4, 7, 2, 1, 5, 3 }.Select(v => new Node<int>(v)).ToArray();
        Node<int>? tree = Balancing.GetBalancedTree(nodes);
        string treeString = tree.TreeString();
        Assert.AreEqual("(4(2(1(null)(null))(3(null)(null)))(6(5(null)(null))(7(null)(null))))", treeString);
    }
}
