namespace Graph;

public partial class Form1 : Form
{
    private readonly Drawer _drawer;
    private readonly Plane _plane = new();
    private bool _moveNode;
    private bool _preAddNode;
    private string _preAddNodeName = string.Empty;

    public Form1()
    {
        InitializeComponent();
        _drawer = new Drawer(Plane.Width, Plane.Height);
        AlgorithmsComboBox.Items.Add("Dijkstra's algorithm");
    }

    private void AddNodeButton_Click(object sender, EventArgs e)
    {
        var res = MessageBox.Show(
            "Now click at the point on the plane where you want to add a new node.",
            "Add Node",
            MessageBoxButtons.OKCancel);
        if (res == DialogResult.OK)
        {
            _preAddNodeName = NodeNameTextBox.Text.Trim();
            _preAddNode = true;
        }
    }

    private void AddEdgeButton_Click(object sender, EventArgs e)
    {
        var fromNode = FromNodeComboBox.SelectedItem as PlaneElem;
        var toNode = ToNodeComboBox.SelectedItem as PlaneElem;
        var weigth = (double)WeigthNumericUpDown.Value;

        _plane.AddPlaneEdge(fromNode!, toNode!, weigth);
        Plane.Image = _drawer.DrawPlane(_plane.PlaneNodes, _plane.PlaneEdges);
    }

    private void ComputeAlgorithmButton_Click(object sender, EventArgs e)
    {
        switch (AlgorithmsComboBox.SelectedItem)
        {
            case "Dijkstra's algorithm":
                _plane.UnvisitAll();
                var from = FromNodeComboBox.SelectedItem as PlaneElem;
                var to = ToNodeComboBox.SelectedItem as PlaneElem;
                _plane.Dijkstra(from!, to!);
                Plane.Image = _drawer.DrawPlane(_plane.PlaneNodes, _plane.PlaneEdges);
                break;
        }
    }

    private void RedrawGraphButton_Click(object sender, EventArgs e)
    {
        _plane.UnvisitAll();
        Plane.Image = _drawer.DrawPlane(_plane.PlaneNodes, _plane.PlaneEdges);
    }

    private void MoveNodeButton_Click(object sender, EventArgs e)
    {
        var res = MessageBox.Show(
            "Now click at the point on the plane where you want to move selected node.",
            "Move Node",
            MessageBoxButtons.OKCancel);
        if (res == DialogResult.OK) _moveNode = true;
    }

    private void Plane_Click(object sender, EventArgs e)
    {
        if (e is not MouseEventArgs args) return;
        if (_moveNode)
        {
            if (MoveNodeComboBox.SelectedItem is not PlaneElem node) return;
            node.Position = new Point(args.X, args.Y);
            Plane.Image = _drawer.DrawPlane(_plane.PlaneNodes, _plane.PlaneEdges);
            _moveNode = false;
        }

        if (!_preAddNode) return;
        _plane.AddPlaneNode(_preAddNodeName, args.X, args.Y);
        FromNodeComboBox.Items.Add(_plane.PlaneNodes.Last());
        ToNodeComboBox.Items.Add(_plane.PlaneNodes.Last());
        MoveNodeComboBox.Items.Add(_plane.PlaneNodes.Last());
        Plane.Image = _drawer.DrawPlane(_plane.PlaneNodes, _plane.PlaneEdges);
        _preAddNode = false;
    }
}