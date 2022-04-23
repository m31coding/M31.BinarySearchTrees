using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M31.BinarySearchTrees.Tests;

[TestClass]
public class InsertionTests
{
    private static BinarySearchTree<int> CreateTree(params int[] values)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        foreach (int value in values)
        {
            tree.Insert(value);
        }

        return tree;
    }

    [TestMethod]
    public void CanCreateEmptyTree()
    {
        Assert.AreEqual(string.Empty, CreateTree().Root.PreOrderTraversalString());
    }

    [TestMethod]
    public void CanCreateTreeWithOneValue()
    {
        Assert.AreEqual("(7(null)(null))", CreateTree(7).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesOneTwo()
    {
        Assert.AreEqual("(1(null)(2(null)(null)))", CreateTree(1, 2).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesTwoOne()
    {
        Assert.AreEqual("(2(1(null)(null))(null))", CreateTree(2, 1).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesOneTwoThree()
    {
        Assert.AreEqual("(1(null)(2(null)(3(null)(null))))", CreateTree(1, 2, 3).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesOneThreeTwo()
    {
        Assert.AreEqual("(1(null)(3(2(null)(null))(null)))", CreateTree(1, 3, 2).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesTwoThreeOne()
    {
        Assert.AreEqual("(2(1(null)(null))(3(null)(null)))", CreateTree(2, 3, 1).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesTwoOneThree()
    {
        Assert.AreEqual("(2(1(null)(null))(3(null)(null)))", CreateTree(2, 1, 3).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesThreeOneTwo()
    {
        Assert.AreEqual("(3(1(null)(2(null)(null)))(null))", CreateTree(3, 1, 2).Root.TreeString());
    }

    [TestMethod]
    public void CanCreateTreeWithValuesThreeTwoOne()
    {
        Assert.AreEqual("(3(2(1(null)(null))(null))(null))", CreateTree(3, 2, 1).Root.TreeString());
    }
}
