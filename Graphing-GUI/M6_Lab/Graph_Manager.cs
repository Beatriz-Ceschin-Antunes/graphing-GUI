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
    // Graph_Manager class to manage graphs, including adding, revising, and copying graphs.
    public class Graph_Manager
    {
        // Singleton instance of Graph_Manager.
        private static Graph_Manager graphManager = new Graph_Manager();

        // Dictionary to store graphs with graph ID as key and Graph object as value.
        public Dictionary<int, Graph> graphs;

        // Private constructor to prevent instantiation outside of the class.
        private Graph_Manager()
        {
            graphs = new Dictionary<int, Graph>(); // Initialize the dictionary of graphs.
        }

        // Public method to get the singleton instance of Graph_Manager.
        public static Graph_Manager getManager()
        {
            return graphManager; // Return the singleton instance.
        }

        // Create a blank new graph.
        public void addGraph(int graphId)
        {
            // Check if the graph ID is unique (not already in the dictionary).
            if (!(graphs.ContainsKey(graphId)))
            {
                Graph graph = new Graph(graphId); // Create new Graph object.
                graphs.Add(graphId, graph); // Add new graph to the dictionary.
                return; // Exit method.
            }
        }

        // Add new vertex or edit existing vertex, based on ID search.
        public void reviseGraphVertex(int graphId, int vertexId, int x, int y)
        {
            // Check if graph exists in dictionary.
            if (graphs.ContainsKey(graphId))
            {
                Graph graph = graphs[graphId]; // Get the graph object.

                // If vertex exists, update coordinates.
                if (graph.vertices.ContainsKey(vertexId))
                {
                    graph.vertices[vertexId].X_coordinate = x; // Update X coordinate.
                    graph.vertices[vertexId].Y_coordinate = y; // Update Y coordinate.
                    return; // Exit method.
                }

                // If vertex does not exist, create and add a new one.
                Vertex v = new Vertex(vertexId, x, y); // Create new vertex.
                graph.vertices.Add(vertexId, v); // Add vertex to graph.
                return; // Exit method.
            }
        }

        // Add or revise an edge in the graph.
        public void reviseGraphEdge(int graphId, int edgeId, Vertex fromVertex, Vertex toVertex)
        {
            // Check if graph exists in dictionary.
            if (graphs.ContainsKey(graphId))
            {
                Graph graph = graphs[graphId]; // Get the graph object.

                // If edge exists, update its vertices.
                if (graph.edges.ContainsKey(edgeId))
                {
                    graph.edges[edgeId].from_vertex = fromVertex; // Update 'from' vertex.
                    graph.edges[edgeId].to_vertex = toVertex; // Update 'to' vertex.

                    return; // Exit method.
                }

                // If edge does not exist, create and add a new one.
                Edge e = new Edge(edgeId, fromVertex, toVertex); // Create new edge.
                graph.edges.Add(edgeId, e); // Add edge to graph.
                return; // Exit method.
            }
        }

        // Copy an existing graph and register it under a new ID.
        public void copyGraph(int originalGraphId, int newGraphId)
        {
            // Check if original graph exists in dictionary.
            if (graphs.ContainsKey(originalGraphId))
            {
                Graph originalGraph = graphs[originalGraphId]; // Get original graph.

                // Create a copy of the original graph.
                Graph newGraph = (Graph)graphs[originalGraphId].Clone(); // Clone method assumed.

                newGraph.Id = newGraphId; // Assign new ID to copied graph.

                this.graphs.Add(newGraphId, newGraph); // Add new graph copy to dictionary.
                return; // Exit method.
            }
        }
    }
}
