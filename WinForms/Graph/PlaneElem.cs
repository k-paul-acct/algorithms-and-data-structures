using DataStructures;

namespace Graph;

public class PlaneElem
{
    public PlaneElem(Node node, Point position)
    {
        Node = node;
        Position = position;
    }

    public Node Node { get; set; }
    public Point Position { get; set; }

    public override string ToString()
    {
        return Node.Name;
    }
}