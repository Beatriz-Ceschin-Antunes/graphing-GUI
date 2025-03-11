using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    public class Graph : ICloneable
    {
        private int id;
        public Dictionary<int, Vertex> vertices;
        public Dictionary<int, Edge> edges;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Graph(int id)
        {
            Id = id;
            vertices = new Dictionary<int, Vertex>();
            edges = new Dictionary<int, Edge>();
        }

        // Loop through vertices and edges to display graph.
        public void display(Graphics g)
        {
            if (vertices.Count != 0) 
            { 
                foreach (KeyValuePair<int, Vertex> v in vertices)
                {
                    v.Value.drawing(g);
                }
            }
            if (edges.Count != 0)
            {
                foreach (KeyValuePair<int, Edge> e in edges)
                {
                    e.Value.drawing(g);
                }
            }
        }

        
        public object Clone( )
        {
            // Create a copy of the Graph object.
            Graph clone = (Graph)this.MemberwiseClone();

            // Deep copy vertices.
            clone.vertices = new Dictionary<int, Vertex>();
            // Copy vertex values from original graph to cloned graph.
            foreach (KeyValuePair<int, Vertex> v in this.vertices)
            {
                // Create a new Vertex object and copy its properties.
                Vertex newVertex = new Vertex(v.Key, v.Value.X_coordinate, v.Value.Y_coordinate);

                // Add the cloned Vertex to the new dictionary.
                clone.vertices.Add(v.Key, newVertex);
            }

            // Deep copy edges.
            clone.edges = new Dictionary<int, Edge>();
            // Copy edge values from original graph to cloned graph.
            foreach (KeyValuePair<int, Edge> e in this.edges)
            {
                // Create a new Edge object and copy its properties (assuming a constructor or properties to copy)
                Edge newEdge = new Edge(e.Key, e.Value.from_vertex, e.Value.to_vertex);

                // Add the cloned Edge to the new dictionary
                clone.edges.Add(e.Key, newEdge);
            }

            return clone;
        }
    }
}
