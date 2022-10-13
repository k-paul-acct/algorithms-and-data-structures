using DataStructures;

namespace DataStructuresTests;

public class Tests
{
    private Graph _graph;

    [SetUp]
    public void Setup()
    {
        _graph = new Graph();
    }

    [Test]
    public void AddSameNode()
    {
        var node = new Node("A");
        _graph.AddNode(node);
        Assert.Throws<ArgumentException>(() => _graph.AddNode(node));
    }

    [Test]
    public void AddNodeWithSameName()
    {
        var node1 = new Node("A");
        var node2 = new Node("A");
        _graph.AddNode(node1);
        Assert.DoesNotThrow(() => _graph.AddNode(node2));
    }
}