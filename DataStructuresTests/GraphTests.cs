namespace DataStructuresTests;

public class GraphTests
{
    private readonly Graph<string> _graph;

    public GraphTests()
    {
        _graph = new Graph<string>();
    }

    [Fact]
    public void AddSameNode()
    {
        _graph.AddNode("a");
        Assert.Throws<ArgumentException>(() => _graph.AddNode("a"));
    }

    [Fact]
    public void AddNodeWithSameName()
    {
        var exception = Record.Exception(() => _graph.AddNode("A"));
        Assert.Null(exception);
    }
}