namespace DataStructures;

public class Graph
{
    private readonly HashSet<Edge> _edges = new();

    private readonly HashSet<Node> _nodes = new();
    public IEnumerable<Node> Nodes => _nodes;

    public bool AddNode(Node node)
    {
        return _nodes.Add(node);
    }

    public bool AddEdge(Edge edge)
    {
        return _edges.Add(edge);
    }

    public IEnumerable<Edge> AdjacencyList(Node node)
    {
        return _edges.Where(e => e.StartNode == node);
    }
}