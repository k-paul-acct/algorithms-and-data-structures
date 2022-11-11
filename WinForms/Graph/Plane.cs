using DataStructures;

namespace Graph;

public class Plane
{
    private readonly DataStructures.Graph<string> _graph = new();

    public List<PlaneElem> PlaneNodes { get; } = new();
    public List<PlaneEdge> PlaneEdges { get; } = new();

    public void UnvisitAll()
    {
        foreach (var edge in PlaneEdges) edge.Visited = false;
    }

    public void AddPlaneNode(string name, int x, int y)
    {
        PlaneNodes.Add(new PlaneElem(name, new Point(x, y)));
        _graph.AddNode(name);
    }

    public void AddPlaneEdge(PlaneElem startNode, PlaneElem endNode, double weigth)
    {
        var edge = new Edge<>(startNode.Node, endNode.Node, weigth);
        PlaneEdges.Add(new PlaneEdge(edge, startNode, endNode));
        _graph.AddDirectedEdge(startNode, endNode);
    }

    private IEnumerable<PlaneEdge> MakeEdgePath(IList<Node> path)
    {
        for (var i = 0; i < path.Count - 1; i++)
            yield return PlaneEdges
                .Where(x => x.PlaneElemStart.Node == path[i] &&
                            x.PlaneElemEnd.Node == path[i + 1])
                .First();
    }

    public void Dijkstra(PlaneElem from, PlaneElem to)
    {
        var path = _graph.Dijkstra(from.Node, to.Node).ToList();
        foreach (var edge in MakeEdgePath(path)) edge.Visited = true;
    }
}