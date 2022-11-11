namespace Graph;

public class PlaneElem
{
    public PlaneElem(string node, Point position)
    {
        Node = node;
        Position = position;
    }

    public string Node { get; set; }
    public Point Position { get; set; }

    public override string ToString()
    {
        return Node;
    }
}