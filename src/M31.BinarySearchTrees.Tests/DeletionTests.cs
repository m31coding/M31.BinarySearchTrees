using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M31.BinarySearchTrees.Tests;

[TestClass]
public class DeletionTests
{
    private static BinarySearchTree<int> GetTree()
    {
        return TreeBuilder<int>
            .BuildTree(2, b => b
                    .Left(1)
                    .Right(7, b => b
                        .Left(4, b => b
                            .Left(3)
                            .Right(6, b => b
                                .Left(5)))
                        .Right(8)));
    }

    [TestMethod]
    public void CanCreateExpectedTree()
    {
        BinarySearchTree<int> tree = GetTree();
        string treeString = tree.Root.TreeString();
        Assert.AreEqual("(2(1(null)(null))(7(4(3(null)(null))(6(5(null)(null))(null)))(8(null)(null))))", treeString);
    }

    [TestMethod]
    public void CanDeleteLeaf()
    {
        BinarySearchTree<int> tree = GetTree();
        bool deleted = tree.Delete(3);
        Assert.IsTrue(deleted);
        string treeString = tree.Root.TreeString();
        Assert.AreEqual("(2(1(null)(null))(7(4(null)(6(5(null)(null))(null)))(8(null)(null))))", treeString);
    }

    [TestMethod]
    public void CanDeleteNodeWithOneChild()
    {
        BinarySearchTree<int> tree = GetTree();
        bool deleted = tree.Delete(6);
        Assert.IsTrue(deleted);
        string treeString = tree.Root.TreeString();
        Assert.AreEqual("(2(1(null)(null))(7(4(3(null)(null))(5(null)(null)))(8(null)(null))))", treeString);
    }

    [TestMethod]
    public void CanDeleteNodeWithTwoChildren()
    {
        BinarySearchTree<int> tree = GetTree();
        bool deleted = tree.Delete(4);
        Assert.IsTrue(deleted);
        string treeString = tree.Root.TreeString();
        Assert.AreEqual("(2(1(null)(null))(7(5(3(null)(null))(6(null)(null)))(8(null)(null))))", treeString);
    }
}
