using System.Drawing.Drawing2D;

namespace Graph;

public class Drawer
{
    private static readonly Pen _edgePen = new(Color.Black, 2);
    private static readonly Pen _visitedEdgePen = new(Color.Red, 2);
    private static readonly Brush _nodeBrush = new SolidBrush(Color.Blue);
    private readonly Bitmap _plane;
    private int _height;
    private int _width;

    public Drawer(int width, int height)
    {
        _width = width;
        _height = height;
        _plane = new Bitmap(width, height);

        using var capPath = new GraphicsPath();
        capPath.AddLine(-3, -8, 0, 0);
        capPath.AddLine(3, -8, 0, 0);

        _edgePen.CustomEndCap = new CustomLineCap(null, capPath);
        _visitedEdgePen.CustomEndCap = new CustomLineCap(null, capPath);

        capPath.Dispose();
    }

    private void DrawNodes(IEnumerable<PlaneElem> nodes, Graphics g)
    {
        foreach (var node in nodes)
        {
            g.DrawString(
                node.Node.Name,
                new Font("Arial", 10),
                Brushes.Blue,
                node.Position.X + 8,
                node.Position.Y + 8);
            g.FillEllipse(_nodeBrush, node.Position.X, node.Position.Y, 8, 8);
        }
    }

    private void DrawEdges(IEnumerable<PlaneEdge> edges, Graphics g)
    {
        var temp = edges.OrderBy(x => x.Visited);
        foreach (var edge in temp)
        {
            var captionX = (edge.PlaneElemStart.Position.X + edge.PlaneElemEnd.Position.X) / 2;
            var captionY = (edge.PlaneElemStart.Position.Y + edge.PlaneElemEnd.Position.Y) / 2;
            g.DrawLine(edge.Visited ? _visitedEdgePen : _edgePen,
                edge.PlaneElemStart.Position.X + 4, edge.PlaneElemStart.Position.Y + 4,
                edge.PlaneElemEnd.Position.X + 4, edge.PlaneElemEnd.Position.Y + 4);
            g.DrawString(
                edge.Edge.Weight.ToString(),
                new Font("Arial", 8),
                Brushes.Blue,
                captionX - 8,
                captionY - 8);
        }
    }

    public Bitmap DrawPlane(IEnumerable<PlaneElem> nodes, IEnumerable<PlaneEdge> edges)
    {
        using var g = Graphics.FromImage(_plane);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.Clear(Color.White);
        DrawEdges(edges, g);
        DrawNodes(nodes, g);
        g.Flush();
        g.Dispose();

        return _plane;
    }
}