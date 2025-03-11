using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace M6_Lab
{
    public class Graph_Manager
    {
        private static Graph_Manager graphManager = new Graph_Manager();
        public Dictionary<int, Graph> graphs;

        private Graph_Manager()
        {
            graphs = new Dictionary<int, Graph>();
        }

        public static Graph_Manager getManager()
        {
            return graphManager;
        }

        // Create a blank new graph.
        public void addGraph(int graphId)
        {
            // if key is unique, create graph
            if (!(graphs.ContainsKey(graphId)))
            {
                Graph graph = new Graph(graphId);
                graphs.Add(graphId, graph);
                return;
            }

            // if key is not unique, show error message
            Form1.showErrorMessage("A graph with the ID " + graphId.ToString() + " already exists and can only be added once.");
        }

        // Add new vertex or edit existing vertex, based on ID search.
        public void reviseGraphVertex(int graphId, int vertexId, int x, int y)
        {
            // if key found, locate graph
            if (graphs.ContainsKey(graphId))
            {
                Graph graph = graphs[graphId];

                // Search for existing vertex to modify.
                if (graph.vertices.ContainsKey(vertexId))
                {
                    graph.vertices[vertexId].X_coordinate = x;
                    graph.vertices[vertexId].Y_coordinate = y;
                    return;
                }

                // Create new vertex if none was found.
                Vertex v = new Vertex(vertexId, x, y);

                graph.vertices.Add(vertexId, v);
                return;
            }

            Form1.showErrorMessage("Graph with ID " + graphId.ToString() + " was not found. Vertex could not be added/modified.");
        }

        public void reviseGraphEdge(int graphId, int edgeId, Vertex fromVertex, Vertex toVertex)
        {
            // if key found, locate graph
            if (graphs.ContainsKey(graphId))
            {
                Graph graph = graphs[graphId];

                // Search for existing directed edge to modify.
                if (graph.edges.ContainsKey(edgeId))
                {
                    graph.edges[edgeId].from_vertex = fromVertex;
                    graph.edges[edgeId].to_vertex = toVertex;
                    
                    return;
                }

                // Create new directed edge if none was found.
                Edge e = new Edge(edgeId, fromVertex, toVertex);

                graph.edges.Add(edgeId, e);
                return;
            }

            Form1.showErrorMessage("Graph with ID " + graphId.ToString() + " was not found. Edge could not be added/modified.");
        }

        public void copyGraph(int originalGraphId, int newGraphId)
        {
            // if key found, locate graph
            if (graphs.ContainsKey(originalGraphId))
            {
                Graph originalGraph = graphs[originalGraphId];

                // Make a copy of original graph.
                Graph newGraph = (Graph)graphs[originalGraphId].Clone();

                newGraph.Id = newGraphId; // set up new id

                this.graphs.Add(newGraphId, newGraph); // register new copy as new graph
                return;
            }


            // if graph not found
            Form1.showErrorMessage("Graph with ID " + originalGraphId.ToString() + " was not found. A copy could not be created.");
        }
    }
}
