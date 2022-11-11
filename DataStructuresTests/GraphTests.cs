namespace DataStructuresTests;

public class GraphTests
{
    private Graph<string> _graph = null!;

    [SetUp]
    public void Setup()
    {
        _graph = new Graph<string>();
    }

    [Test]
    public void AddSameNode()
    {
        var s = "a";
        _graph.AddNode(s);
        Assert.Throws<ArgumentException>(() => _graph.AddNode(s));
    }

    [Test]
    public void AddNodeWithSameName()
    {
        _graph.AddNode("A");
        Assert.DoesNotThrow(() => _graph.AddNode("A"));
    }
}