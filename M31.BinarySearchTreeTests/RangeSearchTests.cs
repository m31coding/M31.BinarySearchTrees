using M31.BinarySearchTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M31.BinarySearchTreeTests;

[TestClass]
public class RangeSearchTests
{

    private static readonly BinarySearchTree<int> tree =
        TreeBuilder<int>
            .BuildTree(2, b => b
                .Left(1)
                .Right(7, b => b
                    .Left(4, b => b
                        .Left(3)
                        .Right(6, b => b
                            .Left(5)))
                    .Right(8)));


    [TestMethod]
    public void CanGetNodesLessThanMinus10()
    {
        int[] values = tree.GetNodesLessThan(-10).Select(n => n.Value).ToArray();
        int[] expected = Array.Empty<int>();
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesLessThan4()
    {
        int[] values = tree.GetNodesLessThan(4).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesLessThanOrEqual4()
    {
        int[] values = tree.GetNodesLessThanOrEqual(4).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesLessThan10()
    {
        int[] values = tree.GetNodesLessThan(10).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesGreaterThan0()
    {
        int[] values = tree.GetNodesGreaterThan(0).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesGreaterThan5()
    {
        int[] values = tree.GetNodesGreaterThan(5).Select(n => n.Value).ToArray();
        int[] expected = { 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesGreaterThanOrEqual5()
    {
        int[] values = tree.GetNodesGreaterThanOrEqual(5).Select(n => n.Value).ToArray();
        int[] expected = { 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetNodesGreaterThan8()
    {
        int[] values = tree.GetNodesGreaterThan(8).Select(n => n.Value).ToArray();
        int[] expected = Array.Empty<int>();
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRange1()
    {
        int[] values = tree.GetNodesInRange(2, 5).Select(n => n.Value).ToArray();
        int[] expected = { 2, 3, 4, 5 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRange2()
    {
        int[] values = tree.GetNodesInRange(2, 10).Select(n => n.Value).ToArray();
        int[] expected = { 2, 3, 4, 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRange3()
    {
        int[] values = tree.GetNodesInRange(-10, 5).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4, 5 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetFullRange()
    {
        int[] values = tree.GetNodesInRange(int.MinValue, int.MaxValue).Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetFullRange2()
    {
        int[] values = tree.GetNodesInRange(int.MinValue, int.MaxValue, excludeLower: true, excludeUpper: true)
            .Select(n => n.Value).ToArray();
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRangeAndExcludeLower()
    {
        int[] values = tree.GetNodesInRange(2, 5, excludeLower: true, excludeUpper: false)
            .Select(n => n.Value).ToArray();
        int[] expected = { 3, 4, 5 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRangeAndExcludeUpper()
    {
        int[] values = tree.GetNodesInRange(2, 5, excludeLower: false, excludeUpper: true)
            .Select(n => n.Value).ToArray();
        int[] expected = { 2, 3, 4 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetRangeAndExcludeLowerAndUpper()
    {
        int[] values = tree.GetNodesInRange(2, 5, excludeLower: true, excludeUpper: true)
            .Select(n => n.Value).ToArray();
        int[] expected = { 3, 4 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetSingleNode()
    {
        int[] values = tree.GetNodesInRange(2, 2, excludeLower: false, excludeUpper: false)
            .Select(n => n.Value).ToArray();
        int[] expected = { 2 };
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetEmptyRange1()
    {
        int[] values = tree.GetNodesInRange(4, 2, excludeLower: true, excludeUpper: true)
            .Select(n => n.Value).ToArray();
        int[] expected = Array.Empty<int>();
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetEmptyRange2()
    {
        int[] values = tree.GetNodesInRange(2, 2, excludeLower: true, excludeUpper: false)
            .Select(n => n.Value).ToArray();
        int[] expected = Array.Empty<int>();
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void CanGetEmptyRange3()
    {
        int[] values = tree.GetNodesInRange(2, 2, excludeLower: false, excludeUpper: true)
            .Select(n => n.Value).ToArray();
        int[] expected = Array.Empty<int>();
        CollectionAssert.AreEqual(expected, values);
    }
}
