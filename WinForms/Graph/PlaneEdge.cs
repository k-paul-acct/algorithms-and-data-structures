namespace Graph;

public class PlaneEdge
{
    public bool Visited = false;

    public PlaneEdge(Edge edge, PlaneElem planeElemStart, PlaneElem planeElemEnd)
    {
        Edge = edge;
        PlaneElemStart = planeElemStart;
        PlaneElemEnd = planeElemEnd;
    }

    public Edge Edge { get; set; }
    public PlaneElem PlaneElemStart { get; set; }
    public PlaneElem PlaneElemEnd { get; set; }
}