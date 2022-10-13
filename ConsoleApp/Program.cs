using Algorithms;
using DataStructures;

var graph = new Graph();
var a = new Node("A");
var b = new Node("B");
var c = new Node("C");
var d = new Node("D");
var e = new Node("E");
var f = new Node("F");
var g = new Node("G");

graph.AddNode(a);
graph.AddNode(b);
graph.AddNode(c);
graph.AddNode(d);
graph.AddNode(e);
graph.AddNode(f);
graph.AddNode(g);

graph.AddEdge(new Edge(a, b, 2));
graph.AddEdge(new Edge(b, a, 2));

graph.AddEdge(new Edge(a, c, 3));
graph.AddEdge(new Edge(c, a, 3));

graph.AddEdge(new Edge(a, d, 6));
graph.AddEdge(new Edge(d, a, 6));

graph.AddEdge(new Edge(b, c, 4));
graph.AddEdge(new Edge(c, b, 4));

graph.AddEdge(new Edge(b, e, 9));
graph.AddEdge(new Edge(e, b, 9));

graph.AddEdge(new Edge(c, d, 1));
graph.AddEdge(new Edge(d, c, 1));

graph.AddEdge(new Edge(c, e, 7));
graph.AddEdge(new Edge(e, c, 7));

graph.AddEdge(new Edge(c, f, 6));
graph.AddEdge(new Edge(f, c, 6));

graph.AddEdge(new Edge(d, f, 4));
graph.AddEdge(new Edge(f, d, 4));

graph.AddEdge(new Edge(e, f, 1));
graph.AddEdge(new Edge(f, e, 1));

graph.AddEdge(new Edge(e, g, 5));
graph.AddEdge(new Edge(g, e, 5));

graph.AddEdge(new Edge(f, g, 8));
graph.AddEdge(new Edge(g, f, 8));

var path = graph.Dijkstra(a, g);

foreach (var n in path) Console.Write($"{n.Name} -> ");